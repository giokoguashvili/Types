using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Core.Union.Kind2
{
    public abstract class TUnion<T0> : IUnion<T0>
        where T0 : class
    {
        private readonly Func<object> _value;

        protected TUnion(Func<TUnion<T0>> factory) => _value = factory;

        protected TUnion(T0 value) => _value = () => value;

        public object Value() => _value();
    }
}
