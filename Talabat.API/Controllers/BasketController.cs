using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Baskt>> GetAsync(string id)
        {

            var basket = await basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new Baskt(id));

        }
        [HttpPost]
        public async Task<ActionResult<Baskt>> UpdateAsync(Baskt basket)
        {
            var CreatedOrUpdatedBasket=await basketRepository.UPdateBsketAsync(basket);
            if (CreatedOrUpdatedBasket == null)
                return BadRequest("not found");

            return Ok(CreatedOrUpdatedBasket);
           

        }
        [HttpDelete]
        public async Task DeleteAsync(string id) { 
               await basketRepository.DeleteBasketAsync(id);
        }

    }
}
