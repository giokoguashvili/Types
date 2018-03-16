using System;
using System.Collections.Generic;
using System.Linq;
using Types.Core.Either.Monad;

namespace Types.Core.List.Monad
{
    public static class Monad
    {
        public static M0 Retrun<M0, T1>(this TList<T1>.ParentType<M0> monad)
            where M0 : IMonad<M0, EmptyList, T1>
            where T1 : class
        {
            return new Factory<M0, EmptyList>(monad, new EmptyList()).Instance();
        }

        public static M0 Retrun<M0, T1>(this TList<T1>.ParentType<M0> monad, T1 value)
            where M0 : IMonad<M0, EmptyList, T1>
            where T1 : class
        {
            return new Factory<M0, T1>(monad, value).Instance();
        }

        public static M1 Bind<M0, M1, T1, T2>(this TList<T1>.ParentType<M0> monad, Func<T1, IMonad<M1, EmptyList, T2>> m)
            where M0 : IMonad<M0, EmptyList, T1>
            where M1 : List<T2>, IMonad<M1, EmptyList, T2> 
            where T1 : class
            where T2 : class
        {
            var obj = m(monad.First());  
            return new Factory<M1, IEnumerable<T2>>(
                    obj, 
                        monad
                            .SelectMany(
                                x => new Factory<M1, IEnumerable<T2>>(
                                        obj, 
                                        ((M1)m(x)).Select(y => y)
                                    ).Instance()
                            )
                            .Select(x => x)
                    )
                    .Instance();
        }
    }
}
