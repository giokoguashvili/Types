using System;

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

        public static Either<T0, TR> Apply<A0, A1, T0, TI, TR>(
            this TEither<T0, IFunc<TI, TR>>.P<A0> a,
            TEither<T0, TI>.P<A1> fm
        )
            where A0 : TApplicative<IFunc<TI, TR>>.T<T0>.P<A0>
            where A1 : TApplicative<TI>.T<T0>.P<A1>
        {
            return a.Match(
                (l) => new Factory<Either<T0, TR>>(l).Instance(),
                (r) => fm
                    .Match(
                        (ll) =>
                            new Factory<Either<T0, TR>>(ll).Instance(),
                        (rr) =>
                            new Factory<Either<T0, TR>>(r.Execute(rr)).Instance()
                    )
            );
        }
    }
}