using System;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Monads
{
    public abstract class TEither<T0, T1>
        where T0 : class
        where T1 : class
    {
        public abstract class M<M0> :
            IUnion<T0, T1>,
            IFunctor<Either<T0, T1>, T0, T1>, 
            IMonad<M0, T0, T1>
            where M0 : IMonad<M0, T0, T1>

        {
            private readonly TUnion<T0, T1> _union;
            public M(T0 value)
            {
                _union = new TUnion<T0, T1>(value);
            }
            public M(T1 value)
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

            public M0 Retrun(T0 value)
            {
                return new Factory<M0, T0>(this, value).Instance();
            }
  
            public M0 Retrun(T1 value)
            {
                return new Factory<M0, T1>(this, value).Instance();
            }

            public Either<T0, T1> RetrunF(T0 value)
            {
                return new Factory<Either<T0, T1>, T0>(this, value).Instance();
            }

            public Either<T0, T1> RetrunF(T1 value)
            {
                return new Factory<Either<T0, T1>, T1>(this, value).Instance();
            }
        }
    }
}
