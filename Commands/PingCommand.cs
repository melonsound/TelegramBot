using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class PingCommand : IBotCommand
    {
        private readonly ICounterData _counter;

        public PingCommand(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "ping";

        public string Description => "This is a simple command that can be used to test if the bot is online";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string? commandText)
        {
            var result = await _counter.CreateCounter(new DataAccess.Models.CreateCounterBody { CounterTitle = commandText, UserId = userId});
            await chatService.SendMessage(chatId, result);
        }
    }
}
