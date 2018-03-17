using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public class TEither<TLeft, TRight>
        where TLeft : class
        where TRight : class
    {
        public abstract class IParent<E>
            : Monad<TRight>.IParent<E>
            where E : Monad<TRight>.IParent<E>
        {
            private readonly IUnion<TLeft, TRight> _union;
            private readonly Monad<TRight>.IParent<E> _eitherMonad;

            public IParent(
                IUnion<TLeft, TRight> union,
                Monad<TRight>.IParent<E> eitherMonad
            )
            {
                _union = union;
                _eitherMonad = eitherMonad;
            }

            public M1 Bind<M1, T1>(Func<TRight, Monad<T1>.IParent<M1>> m)
                where M1 : Monad<T1>.IParent<M1>
                where T1 : class
            {
                return _eitherMonad.Bind(m);
            }

            public TRight Value()
            {
                return _union.Match(e => (TRight)null, r => r);
            }
        }

    }
}
