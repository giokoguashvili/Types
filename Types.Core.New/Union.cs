using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Core.New
{
    //public interface IUnion<T0, T1>
    //{
    //    TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1);
    //}

    public abstract class TUnion<T0, T1>
    {
        public interface IParent<U>
        {
            TResult Match<TResult>(Func<T0, TResult> f0, Func<T1, TResult> f1);
        }
    }

    public class Union<T0, T1> : AUnion<Union<T0, T1>, T0, T1>
    {
        public Union(Func<TUnion<T0, T1>> factory) : base(factory)
        {
        }

        public Union(T0 value) : base(value)
        {
        }

        public Union(T1 value) : base(value)
        {
        }
    }

    public class AUnion<P, T0, T1> : TUnion<T0, T1>.IParent<P>
    {
        private readonly Func<object> _lazyValue;

        public AUnion(Func<TUnion<T0, T1>> factory) => _lazyValue = factory;

        public AUnion(T0 value) => _lazyValue = () => value;

        public AUnion(T1 value) => _lazyValue = () => value;

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
