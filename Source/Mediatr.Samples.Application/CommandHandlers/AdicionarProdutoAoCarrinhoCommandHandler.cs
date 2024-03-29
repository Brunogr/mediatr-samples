﻿using Commander.Abstractions;
using Commander.Core;
using Mediatr.Samples.Domain;
using Mediatr.Samples.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Samples.Application.CommandHandlers
{
    public class AdicionarProdutoAoCarrinhoCommandHandler : CommandHandler<AdicionarProdutoAoCarrinhoCommand>
    {
        private readonly ICarrinhoRepository carrinhoRepository;
        public AdicionarProdutoAoCarrinhoCommandHandler(IHandler handler, 
            ICarrinhoRepository carrinhoRepository) : base(handler)
        {
            this.carrinhoRepository = carrinhoRepository;
        }

        public async override Task<CommandResult> HandleCommandAsync(AdicionarProdutoAoCarrinhoCommand command)
        {
            //Verifica se já existe carrinho para o comprador
            var carrinho = (await carrinhoRepository.GetByFilterAsync(c => c.Comprador.Nome == command.NomeComprador)).FirstOrDefault();

            if (carrinho != null)
            {
                //Atualiza o carrinho
                carrinho.AdicionarProduto(new Produto() { Id = command.IdProduto, Nome = command.NomeProduto, Valor = command.ValorProduto });

                await handler.Validate(carrinho);

                if (carrinho.Invalid)
                    return new CommandResult(false);

                await carrinhoRepository.UpdateAsync(carrinho);
            }
            else
            {
                //Cria um novo carrinho
                carrinho = new Carrinho(new Comprador() { Nome = command.NomeComprador }, new List<Produto>() { new Produto() { Nome = command.NomeProduto, Valor = command.ValorProduto, Id = command.IdProduto } });

                await handler.Validate(carrinho);

                if (carrinho.Invalid)
                    return new CommandResult(false);

                await carrinhoRepository.InsertAsync(carrinho);
            }

            //Levanta eventos
            await AddEventsAsync(carrinho.DomainEvents.ToArray());

            return new CommandResult(true, carrinho);
        }
    }
}
