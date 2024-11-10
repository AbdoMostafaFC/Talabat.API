using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Specification;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repos
{
    public class GenericRepository<T> : IgenericRepository<T> where T : baseEntity
    {
        private readonly StoreContext context;

        public GenericRepository(StoreContext context)
        {
           this.context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await  context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>>GetAllWithSpec(Ispecification<T>spec)
        {

           
           
             
            return await SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec).ToListAsync();
        }

        public async Task<T?> GetByWithSpec(Ispecification<T> spec)
        {
            return await SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec).FirstOrDefaultAsync();

        }
    }
}
