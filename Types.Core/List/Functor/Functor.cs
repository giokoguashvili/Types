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
        public static Listt<T2> Fmap<T1, T2>(this Listt<T1> functor, Func<T1, T2> fmap)
            where T1 : class
            where T2 : class
        {
            return new Listt<T2>(functor.Select(fmap));
        }
    }
}
