using System;
using System.Linq;
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

        public static ListM<T1> Fmap<L0, T0, T1>(
            this TList<T0>.P<L0> list,
            Func<T0, T1> mapper
        )
            where L0 : TFunctor<T0>.T<EmptyList>.P<L0>
        {
            return list
                .Match(
                    l => new ListM<T1>(new EmptyList()),
                    r => new ListM<T1>(r.Select(mapper))
                );
        }
    }
}