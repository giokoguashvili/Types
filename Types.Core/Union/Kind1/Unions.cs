using System;

namespace Types.Core.Union.Kind1
{
    public static class Unions
    {
        public static TResult Match<T0, T1, TResult>(
            this IUnion<T0, T1> u,
            Func<T0, TResult> f1,
            Func<T1, TResult> f2
        )
            where T0 : class
            where T1 : class
        {
            var value = u.Value();
            switch (value)
            {
                case T0 variable:
                    return f1(variable);
                case T1 _:
                    return f2((T1)value);
            }
            throw new Exception("can't match");
        }
    }
}
