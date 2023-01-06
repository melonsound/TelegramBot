using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess.Models;

namespace TgBotAspNet.DataAccess
{
    public interface ICounterData
    {
        [Get("/api/counter")]
        Task<List<Counter>> GetCounters();

        [Post("/api/counter/create-counter")]
        Task<string> CreateCounter([Body] CreateCounterBody counter);
    }
}
