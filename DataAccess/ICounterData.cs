using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using TgBotAspNet.DataAccess.Models;

namespace TgBotAspNet.DataAccess
{
    public interface ICounterData
    {
        [Get("/api/counters/{userId}")]
        Task<List<Counter>> GetCounters(long userId);

        [Post("/api/counters/create-counter")]
        Task<string> CreateCounter([Body] CreateCounterBody counter);

        [Put("/api/counters/inc-counter/{userId}/{counterId}")]
        Task<string> IncCounter(long userId, long counterId);
    }
}
