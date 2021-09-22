using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TgBotAspNet.Services
{
    public class NoSleepService : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NoSleepService> _logger;
        private Timer _timer;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _host;

        public NoSleepService(IHttpClientFactory clientFactory, ILogger<NoSleepService> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;
            _host = _configuration.GetValue<string>("CurrentHost");

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start No Sleep Service");
            _timer = new Timer(SelfRequest, null, TimeSpan.Zero, TimeSpan.FromMinutes(40));
            

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
         
        private async void SelfRequest(object state)
        {
            _logger.LogInformation("Self Request");
            var request = new HttpRequestMessage(HttpMethod.Get,$"{_host}/config/entity");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    string value = reader.ReadToEnd();
                    _logger.LogInformation(value);
                    // Do something with the value
                }
            }
            else
            {
                _logger.LogInformation("Error request");
            }
        }
    }
}
