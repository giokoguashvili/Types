using System;
using System.Linq;
using Monads.Core.Either.Type;
using Monads.Core.Monads;

namespace Monads.Core.Either
{
    public static class Functor
    {
        public static Either<T0, T2> Fmap<F0, T0, T1, T2>(
            this TEither<T0, T1>.P<F0> e,
            Func<T1, T2> f
        )
            where F0 : TFunctor<T1>.T<T0>.P<F0>
        {
            return e
                .Match(
                    (l) => new Factory<Either<T0, T2>>(l).Instance(),
                    (r) => new Factory<Either<T0, T2>>(f(r)).Instance()
                );
        }

        
    }
}