using System;
using Monads.Core.Unit;

namespace Monads.Core.Either
{
    public class Either<TLeft, TRight> : TEither<TLeft, TRight>.P<Either<TLeft, TRight>>
    {
        public Either(TLeft t0) : base(t0)
        {
        }

        public Either(TRight t1) : base(t1)
        {
        }
    }

    public class Either<TLeft, TInput, TResult>
        : TEither<TLeft, IFunc<TInput, TResult>>.P<Either<TLeft, TInput, TResult>>
    {
        public Either(Func<TInput, TResult> func)
            : this(new F<TInput, TResult>(func))
        {
                
        }
        public Either(Func<TUnion<TLeft, IFunc<TInput, TResult>>> factory) : base(factory)
        {
        }

        public Either(TLeft value) : base(value)
        {
        }

        public Either(IFunc<TInput, TResult> value) : base(value)
        {
        }
    }


    public interface IFunc<in TInput, out TResult>
    {
        TResult Execute(TInput value);
    }

    public class F<TInput, TResult> : IFunc<TInput, TResult>
    {
        private readonly Func<TInput, TResult> _func;

        public F(Func<TInput, TResult> func)
        {
            _func = func;
        }

        public TResult Execute(TInput value)
        {
            return _func(value);
        }
    }
}