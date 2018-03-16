using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.Core.Either;
using Types.Core.Either.Monad;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.List.Functor
{
    public static class Functor
    {
        public static TList<T1> RetrunF<F0, T1>(this TList<T1>.T<F0> functor, T1 value)
            where F0 : IMonad<F0, EmptyList, T1>
            where T1 : class
        {
            return new Factory<TList<T1>, T1>(functor, value).Instance();
        }

        public static EmptyList RetrunF<F0, T0, T1>(this TList<T1>.T<F0> functor, T0 empty)
            where F0 : IMonad<F0, EmptyList, T1>
            where T1 : class
            where T0 : EmptyList
        {
            return new Factory<EmptyList, T0>(functor, empty).Instance();
        }

        public static Listt<T2> Fmap<T1, T2>(this Listt<T1> functor, Func<T1, T2> fmap)
            where T1 : class
            where T2 : class
        {
            return new Listt<T2>(functor.Select(fmap));
        }
    }
}
