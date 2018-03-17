using System;

namespace Types.Core.New.Union
{
    public interface IUnion<out T0, out T1>
    {
        TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1);
    }
}