using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repository.Contract
{
    public interface IgenericRepository<T>where T : baseEntity
    {

        
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public  Task<IEnumerable<T>> GetAllWithSpec(Ispecification<T> spec);
        public  Task<T> GetByWithSpec(Ispecification<T> spec);


    }
}
