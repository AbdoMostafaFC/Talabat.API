using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    public static class SpecificationEvaluator<T>where T : baseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> context,Ispecification<T>Spec)
        {
            IQueryable<T> gg = null;
           if(Spec.Critira is not null)
              gg= context.Where(Spec.Critira);

           if(Spec.OrederBy is not null &&  !(Spec.Critira is null))
            {
              gg =gg.OrderBy(Spec.OrederBy);
            }
           else if(Spec.OrederByDesc is not null && !(Spec.Critira is null))
             gg= gg.OrderByDescending(Spec.OrederByDesc);
            //else
            if (Spec.Ispagination)

                gg = gg.Skip(Spec.skip).Take(Spec.take);

          var con=Spec.Includes.Aggregate(gg,(currentContect,includeExpresion)=>currentContect.Include(includeExpresion));
            return con;
        }
    }
}
