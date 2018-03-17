using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public abstract class TFunctor<T0>
        where T0 : class
    {
        public abstract class THead<TH>
            where TH : class
        {
            public interface IParent<F0>
            {
                F0 Fmap<T1>(Func<T0, T1> f)
                    where T1 : class;
                    
            }
        }
    }

    public interface IFunc<T0, T1>
    {
        T1 Run(T0 value);
    }
    public abstract class TApplicative<T0>
        where T0 : class
    {
        public abstract class THead<TH>
            where TH : class
        {
            public interface IParent<A0>
            {
                A0 Prune(T0 value);
                A0 Apply<A1, T2>(TEither<TH, IFunc<T0, T2>>.IParent<A1> app)
                    where T2 : class;
            }
        }
    }
}
