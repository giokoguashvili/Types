using System;

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
}
