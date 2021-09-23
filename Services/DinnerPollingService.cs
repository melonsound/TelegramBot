using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TgBotAspNet.Models;

namespace TgBotAspNet.Services
{
    public class DinnerPollingService : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DinnerPollingService> _logger;
        private IChatService _chatService;
        private Timer _timer;
        private DateTime _dateTime;
        private bool _canSendPoll = true;
        private bool _initAccessTrigger = false;
        private readonly long _chatId;

        private static readonly string _triggerTime = "22:16";
        private static readonly string _resetTime = "14:10";

        public DinnerPollingService(ILogger<DinnerPollingService> logger, IChatService chatService, IConfiguration configuration)
        {
            _configuration = configuration;
            _chatId = Convert.ToInt64(Environment.GetEnvironmentVariable("POLLING_CHAT_ID"));
            _logger = logger;
            _chatService = chatService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(TimeCheck, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            _dateTime = DateTime.Now;
            return Task.CompletedTask;
        }

        private void TimeCheck(object state)
        {
            if (_initAccessTrigger)
            {
                var time = DateTime.Now;
                var currentTime = time.ToString("HH:mm");

                if (time.DayOfWeek != DayOfWeek.Sunday && time.DayOfWeek != DayOfWeek.Saturday)
                {
                    if (currentTime.Equals(_triggerTime))
                    {
                        if (_canSendPoll)
                        {
                            PollContext pollContext = new PollContext();
                            var questionsQuery = pollContext.Questions.ToArray();
                            var pollTitle = pollContext.Polls.First();
                            string[] questions = new string[questionsQuery.Length];

                            for(int i = 0; i < questionsQuery.Length; i++)
                            {
                                questions[i] = questionsQuery[i].Title;
                            }

                            _chatService.SendPoll(_chatId, pollTitle.Title, questions);
                            _canSendPoll = false;
                        }
                    }
                }

                if (currentTime.Equals(_resetTime))
                {
                    _canSendPoll = true;
                }


            }
            _initAccessTrigger = true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
