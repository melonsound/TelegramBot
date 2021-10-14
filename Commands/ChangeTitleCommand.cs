using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgBotAspNet.Models;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class ChangeTitleCommand : IBotCommand
    {
        public string Command => "title";

        public string Description => "Изменить название голосования";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            PollContext pollContext = new PollContext();
            var poll = pollContext.Polls.First();
            poll.Title = commandText;
            pollContext.SaveChanges();

            await chatService.SendMessage(chatId, $"Название голосования изменено на {commandText}");
        }
    }
}
