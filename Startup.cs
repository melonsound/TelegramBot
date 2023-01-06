using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Extensions;
using TgBotAspNet.Services;

namespace TgBotAspNet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddLogging();
            services.AddControllers();
            services.AddSingleton<IChatService, TelegramService>();
            services.AddBotCommands();
            services.AddHostedService<BotService>();
            services.AddRefitClient<ICounterData>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7285"));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
