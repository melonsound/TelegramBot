using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TgBotAspNet.Models;

namespace TgBotAspNet.Services
{
    public interface IChatService
    {
        event EventHandler<ChatMessageEventArgs> ChatMessage;
        event EventHandler<CallbackEventArgs>? Callback;

        Task<string> BotUserName();
        Task<bool> SendMessage(long chatId, string? message, Dictionary<string, string>? buttons = null);
        Task<bool> UpdateMessage(long chatId, int messageId, string newText, Dictionary<string, string>? buttons = null);
        Task<string> GetChatMemberName(long chatId, int userId);
        Task<Message> SendPoll(long chatId, string? question, string[] options);
        Task<Poll> StopPoll(long chatId, int messageId);
    }
}
