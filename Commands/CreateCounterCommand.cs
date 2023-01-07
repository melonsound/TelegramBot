using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class CreateCounterCommand : IBotCommand
    {
        private ICounterData _counter;

        public CreateCounterCommand(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "ccounter";

        public string Description => "Создать счетчик";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            if (string.IsNullOrEmpty(commandText))
            {
                await chatService.SendMessage(chatId, "Введите название счетчика после команды 'ccounter', пример: /ccounter <название счетчика>",  MenuHelper.BackButton);
            }
            else
            {
                var result = await _counter.CreateCounter(new DataAccess.Models.CreateCounterBody { CounterTitle = commandText, UserId = userId });
                await chatService.SendMessage(chatId, result, MenuHelper.BackButton);
            }
        }
    }
}
