using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public interface IEither<TParent, TLeft, TRight> :
               IUnion<TLeft, TRight>,
               TMonad<TRight>.IParent<TParent>
        where TRight : class
        where TLeft : class
    {

    }
    public abstract class TEither<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        public abstract class IParent<E> :
            IEither<E, TLeft, TRight>
            where E : TMonad<TRight>.IParent<E>
        {
           
            private readonly IUnion<TLeft, TRight> _union;
            private readonly TMonad<TRight>.IParent<E> _eitherMonad;

            public IParent(
                IUnion<TLeft, TRight> union,
                TMonad<TRight>.IParent<E> eitherMonad
            )
            {
                _union = union;
                _eitherMonad = eitherMonad;
            }

            public M1 Bind<M1, T1>(Func<TRight, TMonad<T1>.IParent<M1>> m)
                where M1 : TMonad<T1>.IParent<M1>
                where T1 : class
            {
                return _eitherMonad.Bind(m);
            }

            public TResult Match<TResult>(Func<TLeft, TResult> f0, Func<TRight, TResult> f1)
            {
                return _union.Match(f0, f1);
            }
        }
    }
}
