using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public abstract class TEither<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        public abstract class IParent<E> : IEither<E, TLeft, TRight>
        {
           
            private readonly IUnion<TLeft, TRight> _union;
            private readonly TMonad<TRight>.THead<TLeft>.IParent<E> _eitherMonad;
            private readonly TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>> _eitherFunctor;

            public IParent(TLeft left) 
                : this(new Union<TLeft, TRight>(left)) {}
            public IParent(TRight right) 
                : this(new Union<TLeft, TRight>(right)) {}

            private IParent(IUnion<TLeft, TRight> union)
                : this(
                      union, 
                      new EitherMonad<TLeft, TRight>.TParent<E>(union),
                      new EitherFunctor<TLeft, TRight>.TParent<Either<TLeft, TRight>>(union)
                  ) {}

            private IParent(
                IUnion<TLeft, TRight> union,
                TMonad<TRight>.THead<TLeft>.IParent<E> eitherMonad,
                TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>> eitherFunctor
            )
            {
                _union = union;
                _eitherMonad = eitherMonad;
                _eitherFunctor = eitherFunctor;
            }

            public M1 Bind<M1, T1>(Func<TRight, TMonad<T1>.THead<TLeft>.IParent<M1>> m)
                where M1 : TMonad<T1>.THead<TLeft>.IParent<M1>
                where T1 : class
            {
                return _eitherMonad.Bind(m);
            }

            public Either<TLeft, TRight> Fmap<T1>(Func<TRight, T1> f) where T1 : class
            {
                return _eitherFunctor.Fmap(f);
            }

            public TResult Match<TResult>(Func<TLeft, TResult> f0, Func<TRight, TResult> f1)
            {
                return _union.Match(f0, f1);
            }

  
        }
    }
}
