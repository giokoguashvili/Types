using System;

namespace Types.Core.Union.Kind2
{

    public class Union<T0, T1> : TUnion<T0, T1>
        where T0 : class
        where T1 : class
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
}
