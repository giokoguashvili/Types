using System;

namespace Types.Core.Union.Kind2
{
    public abstract class IUnion<T0, T1>
        where T0 : class
        where T1 : class
    {
        private readonly Func<object> _value;

        public IUnion(Func<IUnion<T0, T1>> factory)
        {
            _value = factory;
        }

        public IUnion(T0 value)
        {
            _value = () => value;
        }

        public IUnion(T1 value)
        {
            _value = () => value;
        }

        public object Value()
        {
            return _value();
        }

        public interface IMatcher<out TResult>
        {
            TResult F0(T0 t);
            TResult F1(T1 t);
        }
    }
}
