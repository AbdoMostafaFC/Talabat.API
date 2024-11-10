using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    public class BaseSpecification<T> : Ispecification<T> where T : baseEntity
    {
        public Expression<Func<T, bool>> Critira { get; set; } = null;
        public List<Expression<Func<T, object?>>> Includes { get; set; } = new List<Expression<Func<T, object?>>>() { };
        public Expression<Func<T, object>> OrederBy { get; set; } = null;
        public Expression<Func<T, object>> OrederByDesc { get; set; } = null;
        public int take { get; set; } = 5;
        public int skip { get; set; } = 1;
        public bool Ispagination { get; set; } = false;

        public BaseSpecification()
        {
           
            
        }
        public BaseSpecification(Expression<Func<T,bool>> critira)
        {
            Critira = critira;
        }
        public void addOrderBy(Expression<Func<T, object>> orderBy)
        {
           this.OrederBy = orderBy;
        }
        public void addOrderByDES(Expression<Func<T, object>> orderByDES)
        {
            this.OrederByDesc = orderByDES;
        }

        public void AspPagination(int pageSize,int pageindex)
        {
            Ispagination=true;
             this.take = pageSize;
            this.skip = pageindex;
        }
    }
}
