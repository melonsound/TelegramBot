using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public interface IBotCommand
    {
        string Command { get; }
        string Description { get; }
        bool InternalCommand { get; }

        Task Execute(IChatService chatService, long chatId, long userId, int messageId, string? commandText);
    }
}
