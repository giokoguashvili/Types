using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.Monads;
using Types.Core.Union.Kind2;

namespace Types.Core
{
    public interface IFunctor<F0, T0, T1>
        where F0 : IFunctor<F0, T0, T1>, new()
        where T0 : class
        where T1 : class
    {
        F0 RetrunF(T0 value);
        F0 RetrunF(T1 value);
        //F1 Fmap<F1, T2>(Func<T0, T2> fmap)
        //    where F1 : IFunctor<F1, T2, T1>, new()
        //    where T2 : class;
    }

    public static class Functors
    {
        public static Either<T2, T1> Fmap<T0, T1, T2>(this Either<T0, T1> functor, Func<T0, T2> fmap)
            where T0 : class
            where T1 : class
            where T2 : class
        {
            return functor
                .Match(
                    (a) => new Factory<Either<T2, T1>, T2>(functor, fmap(a)).Instance(),
                    (e) => new Factory<Either<T2, T1>, T1>(functor, e).Instance()
                );
        }
    }
}
