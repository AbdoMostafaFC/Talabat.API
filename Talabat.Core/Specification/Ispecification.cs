using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public interface Ispecification<T> where T : baseEntity
    {
        public Expression<Func<T, bool>> Critira {set;get;}

        public List<Expression<Func<T, Object?>>> Includes { set; get; }
        public Expression<Func<T, object>> OrederBy { get; set; }
        public Expression<Func<T, object>> OrederByDesc { get; set; }
        public int take {  set; get; }
        public int skip { set; get; }
        bool Ispagination { set; get; }

    }
}
