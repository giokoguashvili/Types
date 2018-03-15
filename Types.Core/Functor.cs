﻿using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.Monads;

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
            where F1 : class, IFunctor<F1, T2, T1>, new()
            where T2 : class;
    }

    public interface IEitherFunctor<T0, T1> : IFunctor<Either<T0, T1>, T0, T1>
        where T0 : class
        where T1 : class
    {
        Either<T2, T1> Fmap<T2>(Func<T0, T2> fmap)
            where T2 : class;
    }
}
