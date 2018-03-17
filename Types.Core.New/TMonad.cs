using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public abstract class TMonad<T0>
        where T0: class
    {
        public abstract class THead<TH>
        {
            public interface IParent<M0>
            {
                M1 Bind<M1, T1>(Func<T0, TMonad<T1>.THead<TH>.IParent<M1>> m)
                    where T1 : class
                    where M1 : TMonad<T1>.THead<TH>.IParent<M1>;
            }
        }
    }

    public abstract class TFunctor<T0>
    {

    }
}
