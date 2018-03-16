using System;
using Types.Core.Either;
using Types.Core.Either.Functor;
using Types.Core.Either.Monad;
using Types.Core.Union;

namespace Types.Core.Either
{
    public abstract class TEither<T0, T1>
        where T0 : class
        where T1 : class
    {
        public abstract class T<M0> : 
            TUnion<T0, T1>,
            IFunctor<Either<T0, T1>, T0, T1>,
            IMonad<M0, T0, T1>
            where M0 : IMonad<M0, T0, T1>

        {
            protected T(Func<TUnion<T0, T1>> factory) : base(factory)
            {
            }

            protected T(T0 value) : base(value)
            {
            }

            protected T(T1 value) : base(value)
            {
            }
        }
    }
}
