using Commander.Abstractions;
using Commander.Core.Validators;
using Flunt.Validations;
using Mediatr.Samples.Domain;
using Mediatr.Samples.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Samples.Application.Validators
{
    public class VerificaEstoqueCarrinhoValidator : ValidatorHandler<Carrinho>
    {
        private readonly IEstoqueRepository estoqueRepository;

        public VerificaEstoqueCarrinhoValidator(IDomainNotificationService domainNotificationService,
            IEstoqueRepository estoqueRepository) : base(domainNotificationService)
        {
            this.estoqueRepository = estoqueRepository;
        }

        protected override async Task<bool> ValidateAsync(Carrinho message)
        {
            var idProdutos = message.Produtos.Select(p => p.Id).ToList();
            var estoqueProdutos = await estoqueRepository.GetByFilterAsync(e => idProdutos.Contains(e.Produto.Id));

            foreach (var estoque in estoqueProdutos)
            {
                var quantidadeProduto = message.Produtos.Where(p => p.Id == estoque.Produto.Id).Count();

                if (estoque.QuantidadeDisponivel < quantidadeProduto)
                AddNotification("Carrinho.Produtos", 
                    $"O poduto {estoque.Produto.Nome} não possui unidades o suficiente em estoque");   
            }

            message.AddNotifications(Notifications);

            return Valid;
        }
    }
}
