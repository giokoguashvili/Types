using System;
using System.Collections.Generic;
using System.Data;
using Monads.Core.Monads;
using Monads.Core.Union;

namespace Monads.Core.Either
{
    public abstract class TEither<TLeft>
    {
        public abstract class Func<TInput, TResult>
            : TEither<TLeft, IFunc<TInput, TResult>>.P<Func<TInput, TResult>>
        {
            public Func(Func<TUnion<TLeft, IFunc<TInput, TResult>>> factory) : base(factory)
            {
            }

            public Func(TLeft value) : base(value)
            {
            }

            public Func(IFunc<TInput, TResult> value) : base(value)
            {
            }
        }
    }

    public abstract class TEither<TLeft, TRight>
    {
        public abstract class P<E> :
            TUnion<TLeft, TRight>,
            TMonad<TRight>.T<TLeft>.P<E>,
            TFunctor<TRight>.T<TLeft>.P<E>,
            TApplicative<TRight>.T<TLeft>.P<E>
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

    public class EmptyList { }

    public class ListM<T> : TList<T>.P<ListM<T>>
    {
        public ListM(Func<TUnion<EmptyList, IEnumerable<T>>> factory) : base(factory)
        {
        }

        public ListM() : this(new EmptyList()) {}

        public ListM(EmptyList value) : base(value)
        {
        }

        public ListM(IEnumerable<T> value) : base(value)
        {
        }
    }
    public abstract class TList<T>
    {
        public abstract class P<L> :
            TUnion<EmptyList, IEnumerable<T>>,
            TMonad<T>.T<EmptyList>.P<L>,
            TFunctor<T>.T<EmptyList>.P<L>,
            TApplicative<T>.T<EmptyList>.P<L>
        {
            protected P(Func<TUnion<EmptyList, IEnumerable<T>>> factory) : base(factory)
            {
            }

            protected P(EmptyList value) : base(value)
            {
            }

            protected P(IEnumerable<T> value) : base(value)
            {
            }
        }
    }
}