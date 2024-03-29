﻿using Commander.Abstractions;
using Mediatr.Samples.Domain.Base;
using Mediatr.Samples.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediatr.Samples.Domain
{
    public class Carrinho : AggregateRoot, IValidatable
    {
        protected Carrinho() { }
        public Carrinho(Comprador comprador, List<Produto> produtos)
        {
            Id = Guid.NewGuid();
            Comprador = comprador;
            Produtos = produtos;

            foreach (var produto in Produtos)
            {
                AddEvent(new AtualizarEstoqueEvent(produto.Id));
            }
        }

        public void AdicionarProduto(Produto produto)
        {
            AddEvent(new AtualizarEstoqueEvent(produto.Id));

            this.Produtos.Add(produto);
        }

        public Guid Id { get; set; }
        public Comprador Comprador { get; set; }
        public decimal ValorTotal => Produtos.Select(x => x.Valor).Sum();
        public List<Produto> Produtos { get; private set; }
    }
}
