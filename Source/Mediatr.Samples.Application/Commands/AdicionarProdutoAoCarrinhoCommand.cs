using Commander.Core;
using System;

namespace Mediatr.Samples.Application
{
    public class AdicionarProdutoAoCarrinhoCommand : Command
    {
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public string NomeComprador { get; set; }
        public override bool Validate()
        {
            return true;
        }
    }
}
