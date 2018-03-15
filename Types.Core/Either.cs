using System;
using Types.Core.Union;
using Types.Core.Union.Kind2;

namespace Types.Core.Monads
{
    public class Either<T0, T1> : 
        IUnion<T0, T1>,
        IFunctor<Either<T0, T1>, T0, T1>,
        IMonad<Either<T0, T1>, T0, T1>
           where T0 : class
           where T1 : class
    {
        private readonly AUnion<T0, T1> _union;
        public Either(T0 value)
        {
            _union = new AUnion<T0, T1>(value);
        }
        public Either(T1 value)
        {
            _union = new AUnion<T0, T1>(value);
        }
        public Either()
        {

        }

        public object Value()
        {
            return _union.Value();
        }

        public Either<T0, T1> Retrun(T0 value)
        {
            return new Either<T0, T1>(value);
        }

        public Either<T0, T1> Retrun(T1 value)
        {
            return new Either<T0, T1>(value);
        }

        public M1 Bind<M1, T2>(Func<T0, IMonad<M1, T2, T1>> m)
            where M1 : IMonad<M1, T2, T1>, new()
            where T2 : class
        {
            return (M1)this.Match(m, (e) => new M1().Retrun(e));
        }

        public F1 Fmap<F1, T2>(Func<T0, T2> fmap)
            where F1 : IFunctor<F1, T2, T1>, new()
            where T2 : class
        {
            return this.Match(
                        (a) => new F1().Retrun(fmap(a)),
                        (e) => new F1().Retrun(e)
                    );
        }
    }
}
