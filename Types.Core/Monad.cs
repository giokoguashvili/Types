using System;
using Types.Core.Union.Kind2;

namespace Types.Core.Union
{
    public interface IMonad<M0, T0, T1> 
        where M0 : IMonad<M0, T0, T1>, new()
        where T0: class
        where T1 : class
    {
        M0 Retrun(T0 value);
        M0 Retrun(T1 value);
        M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
            where M1 : IMonad<M1, T2, T1>, new()
            where T2 : class;
    }
}