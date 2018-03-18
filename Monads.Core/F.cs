using System;

namespace Monads.Core
{
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