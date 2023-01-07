using System.Threading.Tasks;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class StatCommand : IBotCommand
    {
        public string Command => "stat";

        public string Description => "test";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            await chatService.SendMessageReplyMarkup(chatId, "Меню", new System.Collections.Generic.Dictionary<string, string> {
                { "test", "test" }, 
                { "test1", "test1" }, 
                { "test2", "test2" }, 
                { "test3", "test3" },
                { "test5", "test3" },
                { "test6", "test3" },
                { "test7", "test3" },
                { "test8", "test3" },
                { "test9", "test3" },
                { "test4", "test4" } 
            });
        }
    }
}
