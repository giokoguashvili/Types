using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.Core.Either.Functor;
using Types.Core.Either.Monad;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.List
{
    public static class Monad
    {
        public static M0 Retrun<M0, T1>(this TList<T1>.T<M0> monad)
            where M0 : IMonad<M0, EmptyList, T1>
            where T1 : class
        {
            return new Factory<M0, EmptyList>(monad, new EmptyList()).Instance();
        }

        public static M0 Retrun<M0, T1>(this TList<T1>.T<M0> monad, T1 value)
            where M0 : IMonad<M0, EmptyList, T1>
            where T1 : class
        {
            return new Factory<M0, T1>(monad, value).Instance();
        }

        public static M1 Bind<M0, M1, T1, T2>(this TList<T1>.T<M0> monad, Func<T1, IMonad<M1, EmptyList, T2>> m)
            where M0 : IMonad<M0, EmptyList, T1>
            where M1 : List<T2>, IMonad<M1, EmptyList, T2> 
            where T1 : class
            where T2 : class
        {
            //monad.Aggregate(new Factory<M1, T2>(monad).Instance(), (prev, next) => prev);
            
            return new Factory<M1, IEnumerable<T2>>(monad, monad.SelectMany(x => new Factory<M1, IEnumerable<T2>>(monad, ((M1)m(x)).Select(y => y)).Instance()).Select(x => x)).Instance();
        }
    }
}
