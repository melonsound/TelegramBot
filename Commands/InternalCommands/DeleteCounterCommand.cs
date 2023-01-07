using System;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands.InternalCommands
{
    public class DeleteCounterCommand : IBotCommand
    {
        private readonly ICounterData _counter;

        public DeleteCounterCommand(ICounterData counter)
        {
            _counter = counter;
        }

        public string Command => "deletecounter";

        public string Description => "d";

        public bool InternalCommand => true;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            long counterId = 0;

            try
            {
                counterId = Convert.ToInt64(commandText);
                var result = await _counter.DelCounter(userId, counterId);
                await chatService.SendMessage(chatId, result, MenuHelper.BackButton);
            }
            catch
            {
                await chatService.SendMessage(chatId, "Возникла ошибка", MenuHelper.BackButton);
            }
        }
    }
}
