using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.Either.Functor;
using Types.Core.Either.Monad;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.List
{
    public class Listt<T1> : TList<T1>.T<Listt<T1>>
        where T1 : class
    {
        public Listt(IEnumerable<T1> value) : base(value)
        {
        }
    }

    //public class Lst<T> : List<T>
    //{
    //    public Lst(IEnumerable<T> elems) : base(elems)
    //    {

    //    }
    //}

    public class EmptyList : object
    {

    }

    public abstract class Lst<T1> : List<T1>
    {
        protected Lst(IEnumerable<T1> elems) : base(elems)
        {
                
        }
    }

    public abstract class TList<T1>
        where T1 : class
    { 
        public abstract class T<M0> :
            Lst<T1>,
            IFunctor<Listt<T1>, EmptyList, T1>,
            IMonad<M0, EmptyList, T1>
            where M0 : IMonad<M0, EmptyList, T1>

        {
            protected T(IEnumerable<T1> value) : base(value)
            {
            }
        }
    }
}
