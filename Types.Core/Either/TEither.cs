using System;
using Types.Core.Either;
using Types.Core.Monads;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Either
{
    public abstract class TEither<T0, T1>
        where T0 : class
        where T1 : class
    {
        public abstract class T<M0> : 
            TUnion<T0, T1>,
            IUnion<T0, T1>,
            IFunctor<Either<T0, T1>, T0, T1>,
            IMonad<M0, T0, T1>
            where M0 : IMonad<M0, T0, T1>

        {
            public T(Func<TUnion<T0, T1>> factory) : base(factory)
            {
            }

            public T(T0 value) : base(value)
            {
            }

            public T(T1 value) : base(value)
            {
            }
        }
    }
}
