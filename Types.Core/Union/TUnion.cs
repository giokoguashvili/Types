using System;

namespace Types.Core.Union.Kind2
{
    public abstract class TUnion<T0, T1> : IUnion<T0, T1>
        where T0 : class
        where T1 : class
    {
        private readonly Func<object> _value;

        public TUnion(Func<TUnion<T0, T1>> factory) => _value = factory;

        public TUnion(T0 value) => _value = () => value;

        public TUnion(T1 value) => _value = () => value;

        public object Value() => _value();
    }
}
