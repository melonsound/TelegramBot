using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TgBotAspNet.Models
{
    public class PollContext : DbContext
    {
        public DbSet<PollModel> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=Data/BotDb.sqlite");
        }
    }
}
