using System;
using Types.Core.Union.Kind2;

namespace Types.Core.Union
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
            if (value is T0)
            {
                return f1((T0)value);
            }
            else if (value is T1)
            {
                return f2((T1)value);
            }
            throw new Exception("can't match");
        }

        public static TResult Match<T0, T1, TResult>(this IUnion<T0, T1> u, IUnion<T0, T1>.IMatcher<TResult> matcher)
            where T0 : class
            where T1 : class
        {
            return Match(u, matcher.F0, matcher.F1);
        }
        
    }
}
