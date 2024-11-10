using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Baskt
    {
        public Baskt(string id)
        {
            Id = id;
            basketItems = new List<BasketItem>();
        }

        public string Id { get; set; }
        public List<BasketItem> basketItems { get; set; }
    }
}
