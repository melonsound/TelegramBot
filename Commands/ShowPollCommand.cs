using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgBotAspNet.Models;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class ShowPollCommand : IBotCommand
    {
        public string Command => "showpoll";

        public string Description => "Отобразить голосование";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            PollContext pollContext = new PollContext();
            var questionsQuery = pollContext.Questions.ToArray();
            var pollTitle = pollContext.Polls.First();
            string[] questions = new string[questionsQuery.Length];

            for (int i = 0; i < questionsQuery.Length; i++)
            {
                questions[i] = questionsQuery[i].Title;
            }

            await chatService.SendPoll(chatId, pollTitle.Title, questions);
        }
    }
}
