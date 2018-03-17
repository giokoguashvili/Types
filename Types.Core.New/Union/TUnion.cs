using System;

namespace Types.Core.New.Union
{
    public abstract class TUnion<T0, T1> 
    {
        public abstract class IParent<U> : IUnion<T0, T1>
        {
            private readonly Func<object> _lazyValue;

            protected IParent(Func<TUnion<T0, T1>> factory) => _lazyValue = factory;

            protected IParent(T0 value) => _lazyValue = () => value;

            protected IParent(T1 value) => _lazyValue = () => value;

            public object Value() => _lazyValue();

            public TResult Match<TResult>(
                Func<T0, TResult> f0,
                Func<T1, TResult> f1
            )
            {
                var value = _lazyValue();
                switch (value)
                {
                    case T0 variable:
                        return f0(variable);
                    case T1 _:
                        return f1((T1)value);
                }
                throw new Exception("can't match");
            }
        }

    }
}