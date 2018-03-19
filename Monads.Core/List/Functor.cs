using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monads.Core.Either;
using Monads.Core.List.Type;
using Monads.Core.Monads;
using Qweex.Unions;

namespace Monads.Core.List
{
    public static class Functor
    {
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
