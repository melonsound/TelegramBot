﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TgBotAspNet.Commands;

namespace TgBotAspNet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBotCommands(this IServiceCollection services, Assembly? assembly = null)
        {
            var callingAssembly = assembly ?? Assembly.GetCallingAssembly();
            var typesToRegister = callingAssembly
                .GetTypes()
                .Where(x => typeof(IBotCommand).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var typeToRegister in typesToRegister)
            {
                services.AddTransient(typeof(IBotCommand), typeToRegister);
            }

            return services;
        }
    }
}
