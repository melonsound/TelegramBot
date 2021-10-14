using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TgBotAspNet.Models;
using TgBotAspNet.Services;

namespace TgBotAspNet.Commands
{
    public class ChangeQuestionsCommand : IBotCommand
    {
        public string Command => "answers";

        public string Description => "изменить ответы в голосовании";

        public bool InternalCommand => false;

        public async Task Execute(IChatService chatService, long chatId, long userId, int messageId, string commandText)
        {
            string[] questions = commandText.Split(' ');

            if (questions.Length > 1)
            {
                PollContext pollContext = new PollContext();
                var questionsQuery = pollContext.Questions.ToList();
                List<Question> newQuestionsQuery = new List<Question>();
                questionsQuery.ForEach(x => pollContext.Questions.Remove(x));


                for(int i = 0; i < questions.Length; i++)
                {
                    Question question = new Question();
                    question.Title = questions[i];
                    question.PollModelId = 1;

                    pollContext.Questions.Add(question);
                }

                pollContext.SaveChanges();

                await chatService.SendMessage(chatId, "Ответы изменены");
            }
            else
            {
                await chatService.SendMessage(chatId, "Укажите больше 1-го ответа");
            }

            
        }
    }
}
