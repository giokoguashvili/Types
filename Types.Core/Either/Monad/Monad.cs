using System;
using Types.Core.Union;

namespace Types.Core.Either.Monad
{
    public static class Monad
    {
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
