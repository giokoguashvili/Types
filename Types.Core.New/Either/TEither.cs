using System;
using Types.Core.New.Union;

namespace Types.Core.New.Either
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
            private readonly TApplicative<TRight>.THead<TLeft>.IParent<E> _applicative;

            protected IParent(TLeft left)
                : this(
                      new Union<TLeft, TRight>(left), 
                      new Functor<TLeft, TRight>.TParent<Either<TLeft, TRight>>(
                            new Union<TLeft, TRight>(left)
                      )
                   )
            { }

            protected IParent(TRight right)
                : this(
                      new Union<TLeft, TRight>(right), 
                      new Functor<TLeft, TRight>.TParent<Either<TLeft, TRight>>(
                            new Union<TLeft, TRight>(right)
                      )
                  )
            { }

            private IParent(
                IUnion<TLeft, TRight> union, 
                TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>> eitherFunctor)
                : this(
                      union,
                      new Monad<TLeft, TRight>.TParent<E>(union),
                      eitherFunctor,
                      new Applicative<TLeft, TRight>.TParent<E>(union)
                  )
            { }

            private IParent(
                IUnion<TLeft, TRight> union,
                TMonad<TRight>.THead<TLeft>.IParent<E> eitherMonad,
                TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>> eitherFunctor,
                TApplicative<TRight>.THead<TLeft>.IParent<E> applicative
            )
            {
                _union = union;
                _eitherMonad = eitherMonad;
                _eitherFunctor = eitherFunctor;
                _applicative = applicative;
            }

            public Either<TLeft, TRight> Fmap<T1>(Func<TRight, T1> f) where T1 : class
            {
                return _eitherFunctor.Fmap(f);
            }

            public TResult Match<TResult>(Func<TLeft, TResult> f0, Func<TRight, TResult> f1)
            {
                return _union.Match(f0, f1);
            }

            public E Apply<T2>(IUnion<TLeft, IFunc<TRight, T2>> app)
                    where T2 : class
            {
                return _applicative.Apply(app);
            }

            public M1 Bind<M1, T1>(Func<TRight, TMonad<T1>.THead<TLeft>.IParent<M1>> m) 
                where M1 : TMonad<T1>.THead<TLeft>.IParent<M1> 
                where T1 : class
            {
                return _eitherMonad.Bind(m);
            }
        }
    }
}
