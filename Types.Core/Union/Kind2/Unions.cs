using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Core.Union.Kind2
{
    public static class Unions
    {
        public static TResult Match<T0, TResult>(
            this IUnion<T0> u,
            Func<T0, TResult> f1
        )
            where T0 : class
        {
            var value = u.Value();
            switch (value)
            {
                case T0 variable:
                    return f1(variable);
            }
            throw new Exception("can't match");
        }
    }
}
