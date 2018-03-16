using System;
using Types.Core.Union.Kind2;

namespace Types.Core.Union
{
    public interface IMonad<M0, T0, T1>
        where M0 : IMonad<M0, T0, T1>
        where T0: class
        where T1 : class
    {
    }
}