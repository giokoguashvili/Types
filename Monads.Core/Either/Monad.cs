using System;
using System.Runtime.InteropServices;

namespace Monads.Core.Either
{
    public static class Monad
    {
        public static M1 Bind<M0, M1, T0, T1, T2>(this TEither<T0, T1>.P<M0> e, Func<T1, TMonad<T2>.T<T0>.P<M1>> fm) 
            where M0 : TMonad<T1>.T<T0>.P<M0> 
            => e
                .Match(
                    (l) =>
                        new Factory<M1>(l).Instance(),
                    (r) =>
                        (M1)fm(r)
                );
    }

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