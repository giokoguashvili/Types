using System;
using Types.Core.Either.Monad;
using Types.Core.Union;

namespace Types.Core.Either.Functor
{
    public static class Functor
    {
        public static Either<T0, T1> RetrunF<F0, T0, T1>(this TEither<T0, T1>.T<F0> functor, T0 value)
            where F0 : IMonad<F0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<Either<T0, T1>, T0>(functor, value).Instance();
        }

        public static Either<T0, T1> RetrunF<F0, T0, T1>(this TEither<T0, T1>.T<F0> functor, T1 value)
            where F0 : IMonad<F0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<Either<T0, T1>, T1>(functor, value).Instance();
        }

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
