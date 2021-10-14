using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TgBotAspNet.Models
{
    public class PollModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int PollModelId { get; set; }
        public PollModel PollModel { get; set; }
    }
}
