﻿using Commander.Abstractions;
using Commander.Core;
using Commander.Core.DomainNotifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommanderExtensions
    {
        public static IServiceCollection AddCommander(this IServiceCollection services)
        {
            services.AddMediatR();

            services.AddScoped<IHandler, Handler>();

            return services;
        }

        public static IServiceCollection AddDomainNotification(this IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationService, DomainNotificationService>();

            return services;
        }

        public static IServiceCollection AddCommander(this IServiceCollection services, params Assembly[] assemblies)
        {
            Assembly.Load("Commander.Core");
            if (assemblies.Any())
                services.AddMediatR(assemblies);
            else
            {
                var assembliesNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();

                foreach (var assembly in assembliesNames.Where(x => x.Name.Contains("Commander")))
                {
                    Assembly.Load(assembly);
                }

                services.AddMediatR();
            }
                

            services.AddScoped<IHandler, Handler>();

            return services;
        }
    }
}
