using Mediatr.Samples.Domain.Events;
using Mediatr.Samples.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Samples.Application.EventHandlers
{
    public class AtualizarEstoqueEventHandler : Commander.Core.EventHandler<AtualizarEstoqueEvent>
    {
        private readonly IEstoqueRepository estoqueRepository;
        public AtualizarEstoqueEventHandler(IEstoqueRepository estoqueRepository)
        {
            this.estoqueRepository = estoqueRepository;
        }
        public async override Task HandleEvent(AtualizarEstoqueEvent @event)
        {
            var estoque = (await estoqueRepository.GetByFilterAsync(e => e.Produto.Id == @event.ProdutoId)).FirstOrDefault();

            if (estoque == null)
                return;

            estoque.QuantidadeDisponivel -= @event.Quantidade;

            await estoqueRepository.UpdateAsync(estoque);
        }
    }
}
