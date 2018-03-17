using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public abstract class EitherMonad<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        public class TParent<E>
            : TMonad<TRight>.THead<TLeft>.IParent<E>
        {
            private readonly IUnion<TLeft, TRight> _union;

            public TParent(IUnion<TLeft, TRight> union)
            {
                _union = union;
            }

            public M1 Bind<M1, T1>(Func<TRight, TMonad<T1>.THead<TLeft>.IParent<M1>> m)
                where M1 : TMonad<T1>.THead<TLeft>.IParent<M1>
                where T1 : class
            {
                return _union
                           .Match(
                               (l) => new Factory<M1, TLeft>(l).Instance(),
                               (r) => (M1)m(r)
                           );
            }
        }
    }
}
