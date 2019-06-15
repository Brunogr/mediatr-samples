using Mediatr.Samples.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Samples.Infra.Data.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> InsertAsync(Carrinho estoque);
        Task<Carrinho> UpdateAsync(Carrinho estoque);
        Task<List<Carrinho>> GetAllAsync();
        Task<List<Carrinho>> GetByFilterAsync(Expression<Func<Carrinho, bool>> filter);
    }
}
