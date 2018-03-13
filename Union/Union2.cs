using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Union
{
    public abstract class Union<T1, T2> 
           where T1 : class
           where T2 : class
    {
        private readonly T1 _t1;
        private readonly T2 _t2;
        private object v;

        protected Union(T1 t1) { _t1 = t1; }
        protected Union(T2 t2) { _t2 = t2; }

        protected Union(object v)
        {
            this.v = v;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> f1,
            Func<T2, TResult> f2
        )
        {
            if (_t1 != null)
            {
                return f1(_t1);
            }
            else if (_t2 != null)
            {
                return f2(_t2);
            }
            throw new Exception("can't match");
        }

        //public object Content()
        //{
        //    if (_t1 != null)
        //    {
        //        return _t1;
        //    }
        //    return _t2;
        //}
    }
}
