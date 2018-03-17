using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public abstract class Monad<T0>
        where T0: class
    {
        //public static M1 Bind<M0, M1, T0, T1, T2>(this TEither<T0, T1>.ParentType<M0> monad, Func<T0, IMonad<M1, T2, T1>> m)
        //    where M0 : IMonad<M0, T0, T1>
        //    where M1 : IMonad<M1, T2, T1>
        //    where T0 : class
        //    where T1 : class
        //    where T2 : class
        //{
        //    return (M1)monad.Match(m, (e) => new Factory<M1, T1>(monad, e).Instance());
        //}

        public interface IParent<M0>
        {
            T0 Value();
            M1 Bind<M1, T1>(Func<T0, Monad<T1>.IParent<M1>> m)
                where T1 : class
                where M1 : Monad<T1>.IParent<M1>;
        }
    }
}
