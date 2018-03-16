using System;
using Types.Core.Either;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Monads
{
    public abstract class TEither<T0, T1>
        where T0 : class
        where T1 : class
    {
        public abstract class T<M0> :
            IUnion<T0, T1>,
            IFunctor<Either<T0, T1>, T0, T1>, 
            IMonad<M0, T0, T1>
            where M0 : IMonad<M0, T0, T1>

        {
            private readonly TUnion<T0, T1> _union;
            public T(T0 value)
            {
                _union = new TUnion<T0, T1>(value);
            }

            public T(T1 value)
            {
                _union = new TUnion<T0, T1>(value);
            }

            public object Value()
            {
                return _union.Value();
            }

            public M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
                where M1 : IMonad<M1, T2, T1>
                where T2 : class
            {
                
                return (M1)this.Match(m, (e) => new Factory<M1, T1>(this, e).Instance());
            }
        }
    }

    public static class Monad
    {
        public static M0 Retrun<M0, T0, T1>(this TEither<T0, T1>.T<M0> monad, T0 value)
            where M0 : IMonad<M0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<M0, T0>(monad, value).Instance();
        }

        public static M0 Retrun<M0, T0, T1>(this TEither<T0, T1>.T<M0> monad, T1 value)
            where M0 : IMonad<M0, T0, T1>
            where T0 : class
            where T1 : class
        {
            return new Factory<M0, T1>(monad, value).Instance();
        }
    }
}
