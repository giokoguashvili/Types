using System.Collections.Generic;
using Types.Core.Either.Functor;
using Types.Core.Either.Monad;

namespace Types.Core.List
{
    public abstract class TList<T1>
        where T1 : class
    { 
        public abstract class T<M0> :
            EList<T1>,
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
