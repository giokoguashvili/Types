using System;

namespace Types.Core.New.Either
{
    public abstract class EitherFunctor<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        public class TParent<F>
            : TFunctor<TRight>.THead<TLeft>.IParent<F>
        {
            private readonly TUnion<TLeft, TRight> _union;

            public TParent(TUnion<TLeft, TRight> union)
            {
                _union = union;
            }

            public F Fmap<T1>(Func<TRight, T1> f) where T1 : class
            {
                return _union
                    .Match(
                        (l) => new Factory<F, TLeft>(l).Instance(),
                        (r) => new Factory<F, T1>(f(r)).Instance()
                    );
            }
        }

    }
}
