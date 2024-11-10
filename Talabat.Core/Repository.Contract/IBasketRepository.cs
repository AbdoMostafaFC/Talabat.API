using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Repository.Contract
{
    public interface IBasketRepository
    {
        Task<Baskt?> GetBasketAsync(string BasketID);
        Task<Baskt?> UPdateBsketAsync(Baskt baskt);
        Task<bool> DeleteBasketAsync(string BasketID);

    }
}
