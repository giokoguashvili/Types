using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Types.Core
{
    public class Factory<TResult, TInput>
    {
        private readonly TInput _value;

        public Factory(TInput value)
        {
            _value = value;
        }
        public TResult Instance()
        {
            return (TResult)
                ((typeof(TResult))
                    .GetConstructor(new Type[] { _value.GetType() })
                    .Invoke(new object[] { _value }));
        } 
    }
}
