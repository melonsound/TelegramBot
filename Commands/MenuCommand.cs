using System.Collections.Generic;
using System.Threading.Tasks;
using TgBotAspNet.Helpers;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class MenuCommand : IBotCommand
    {
        public string Command => "menu";

        public string Description => "Меню";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            await chatService.SendMessage(chatId, "Выберите действие", MenuHelper.Menu);
        }
    }
}
