using System;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class IncrementCounterCommand : IBotCommand
    {
        private ICounterData _counter;

        public IncrementCounterCommand(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "inccounter";

        public string Description => "i";

        public bool InternalCommand => true;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            long counterId = 0;

            try
            {
                counterId = Convert.ToInt64(commandText);
                var result = await _counter.IncCounter(userId, counterId);
                await chatService.SendMessage(chatId, result, MenuHelper.BackButton);
            }
            catch
            {
                await chatService.SendMessage(chatId, "Возникла ошибка", MenuHelper.BackButton);
            }
            
        }
    }
}
