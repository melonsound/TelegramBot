using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands.InternalCommands
{
    public class ClearAllCountersAsync : IBotCommand
    {
        private readonly ICounterData _counter;

        public ClearAllCountersAsync(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "clearall";

        public string Description => "c";

        public bool InternalCommand => true;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
                var result = await _counter.ClrAllCounters(userId);
                await chatService.SendMessage(chatId, result, MenuHelper.BackButton);
            
        }
    }
}
