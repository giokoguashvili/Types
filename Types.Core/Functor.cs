using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Core
{
    public interface IFunctor<F0, T0, T1>
        where F0 : IFunctor<F0, T0, T1>, new()
        where T0 : class
        where T1 : class
    {
        F0 Retrun(T0 value);
        F0 Retrun(T1 value);

        F1 Fmap<F1, T2>(Func<T0, T2> fmap)
            where F1 : IFunctor<F1, T2, T1>, new()
            where T2 : class;
    }
}
