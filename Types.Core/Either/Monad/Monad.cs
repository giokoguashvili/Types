using System;
using Types.Core.Monads;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Either
{
    public static class Monad
    {
        public static M0 Retrun<M0, T0, T1>(this TEither<T0, T1>.T<M0> monad, T0 value)
            where M0 : IMonad<M0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<M0, T0>(monad, value).Instance();
        }

        public static M0 Retrun<M0, T0, T1>(this TEither<T0, T1>.T<M0> monad, T1 value)
            where M0 : IMonad<M0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<M0, T1>(monad, value).Instance();
        }

        public static M1 Bind<M0, M1, T0, T1, T2>(this TEither<T0, T1>.T<M0> monad, Func<T0, IMonad<M1, T2, T1>> m)
            where M0 : IMonad<M0, T0, T1>
            where M1 : IMonad<M1, T2, T1>
            where T0 : class
            where T1 : class
            where T2 : class
        {
            return (M1)monad.Match(m, (e) => new Factory<M1, T1>(monad, e).Instance());
        }
    }
}
