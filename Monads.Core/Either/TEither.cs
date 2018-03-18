using System;
using Monads.Core.Unit;

namespace Monads.Core.Either
{
    public abstract class TEither<TLeft, TRight>
    {
        public abstract class P<E> :
            TUnion<TLeft, TRight>,
            TMonad<TRight>.T<TLeft>.P<E>,
            TFunctor<TRight>.T<TLeft>.P<E>
        {
            public P(Func<TUnion<TLeft, TRight>> factory) : base(factory)
            {
            }

            public P(TLeft value) : base(value)
            {
            }

            public P(TRight value) : base(value)
            {
            }
        }
    }
}