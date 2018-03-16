using System;
using Types.Core.Either.Monad;
using Types.Core.Union;
using Types.Core.Union.Kind1;

namespace Types.Core.Either.Functor
{
    public static class Functor
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
