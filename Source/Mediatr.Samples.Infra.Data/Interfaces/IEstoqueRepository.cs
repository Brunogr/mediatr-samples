using Mediatr.Samples.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Samples.Infra.Data.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<Estoque> InsertAsync(Estoque estoque);
        Task<Estoque> UpdateAsync(Estoque estoque);
        Task<List<Estoque>> GetAllAsync();
        Task<List<Estoque>> GetByFilterAsync(Expression<Func<Estoque, bool>> filter);
    }
}
