using System.Collections.Generic;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.DataAccess.Models;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class MyCountersCommand : IBotCommand
    {
        private readonly ICounterData _counter;

        public MyCountersCommand(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "mycounters";

        public string Description => "Мои счетчики";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            var result = await GetMyCounters(userId);
            if(result.Count == 0 || result == null)
            {
                await chatService.SendMessage(chatId, "Нет счетчиков", MenuHelper.BackButton);
            }
            else
            {
                await chatService.SendMessage(chatId, "Выберите", ConvertToButtons(result));
            }

        }

        private Dictionary<string, string> ConvertToButtons(List<Counter> counters)
        {
            Dictionary<string, string> buttons = new Dictionary<string, string>();
            if(counters != null && counters.Count > 0)
            {
                foreach (var counter in counters)
                {
                    buttons.Add($"{counter.Title}: {counter.Value}", $"/inccounter {counter.Id}");
                }
            }
            return buttons;
        }

        private async Task<List<Counter>> GetMyCounters(long userId)
        {
            var result = await _counter.GetCounters(userId);
            return result;
        }
    }
}
