using Mediatr.Samples.Infra.Data;
using Mediatr.Samples.Infra.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{

    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            serviceCollection.AddScoped<IEstoqueRepository, EstoqueRepository>();

            return serviceCollection;
        }
    }
}
