using System;

namespace Types.Core.New.Union
{
    public class Union<T0, T1> : TUnion<T0, T1>.IParent<Union<T0, T1>>
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
