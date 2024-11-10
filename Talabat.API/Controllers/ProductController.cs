using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Repository;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IgenericRepository<Product> context;

        public ProductController(IgenericRepository<Product>context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>>getAll([FromQuery]ProductSpecParams productSpecParams)
        {

            var pro=new ProductSpcification(productSpecParams);
            return await context.GetAllWithSpec(pro);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult< Product>> getById(int id)
        {

            var proSpec=new ProductSpcification(id);
            //return await context.GetByIdAsync(id);
           var x= await context.GetByWithSpec(proSpec);

            return Ok(x);

        }


    }
}
