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
    //public static Either<T2, T1> Fmap<T0, T1, T2>(this Either<T0, T1> functor, Func<T0, T2> fmap)
    //where T0 : class
    //where T1 : class
    //where T2 : class
    //{
    //    return functor
    //        .Match(
    //            (a) => new Factory<Either<T2, T1>, T2>(functor, fmap(a)).Instance(),
    //            (e) => new Factory<Either<T2, T1>, T1>(functor, e).Instance()
    //        );
    //}
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
