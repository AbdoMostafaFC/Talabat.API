using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository
{
    public class ProductSpcification:BaseSpecification<Product>
    {
        public ProductSpcification(ProductSpecParams productSpecParams):base(
             p=>
                 (!productSpecParams.BrandId.HasValue||p.BrandId==productSpecParams.BrandId)&&
                ( !productSpecParams.CategoryId.HasValue || p.CategoryId == productSpecParams.CategoryId)
            
            )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p=>p.Category);
            
            if(! string.IsNullOrEmpty(productSpecParams.sort))
            {

                switch (productSpecParams.sort)
                {
                    case "PriceAS":
                        addOrderBy(p=>p.Price);
                        break;
                    case "PriceDesc":
                        addOrderByDES(p=>p.Price);
                        break;
                    default:
                        addOrderBy(p=>p.Name);
                        break;

                }
            }
            else
            {
                addOrderBy(p=>p.Brand);
            }
            AspPagination((productSpecParams.PageIndex-1)*productSpecParams.PageSize, productSpecParams.PageSize);

        }

        public ProductSpcification(int id) : base(p => p.id==id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
