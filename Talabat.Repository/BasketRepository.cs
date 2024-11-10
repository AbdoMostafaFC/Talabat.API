using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            this.database=redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string BasketID)
        {
            return await database.KeyDeleteAsync(BasketID);
        }

        public async Task<Baskt?> GetBasketAsync(string BasketID)
        {
           var basket= await database.StringGetAsync(BasketID);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Baskt>(basket);


        }

        public async Task<Baskt?> UPdateBsketAsync(Baskt baskt)
        {
         var xx=   await database.StringSetAsync(baskt.Id,JsonSerializer.Serialize(baskt), TimeSpan.FromDays(30));
            if (xx == null) return null;
            return await GetBasketAsync(baskt.Id);
        }
    }
}
