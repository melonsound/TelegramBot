using System.Collections.Generic;

namespace TgBotAspNet.Helpers
{
    public static class MenuHelper
    {
        public const string CREATE_COUNTER = "Создать счетчик";
        public const string CLEAR_COUNTER = "Очистить счетчик";
        public const string GET_TOTAL_STAT = "Получить общую статистику";
        public const string DELETE_COUNTER = "Удалить счетчик";
        public const string BACK = "<< назад";

        public static Dictionary<string, string> Menu
        { 
            get 
            {
                return new Dictionary<string, string>
                {
                    { "Создать счетчик", "/ccounter" },
                    { "Мои счетчики", "/mycounters" },
                    { "Удалить счетчик", "/countersfordelete" },
                    { "Очистить счетчик", "/countersforclear" },
                    { "Очистить все счетчики", "/countersforallclear" }
                };
            } 
        }

        public static Dictionary<string, string> BackButton
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Назад", "/menu" }
                };
            }
        }
    }
}
