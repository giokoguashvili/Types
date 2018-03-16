using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Types.Core
{
    public class Factory<TResult, TInput>
    {
        private readonly object _self;
        private readonly IEnumerable<TInput> _value;

        public Factory(object self) 
            : this(self, new List<TInput>())
        {
            
        }
        public Factory(object self, TInput value)
            : this(self, new List<TInput>() { value })
        {
                
        }
        public Factory(object self, IEnumerable<TInput> value)
        {
            _self = self;
            _value = value;
        }

        private Type[] Type()
        {
            return _value.Select(v => typeof(TInput)).ToArray();
        }
        public TResult Instance()
        {
            return (TResult)_self
                    .GetType()
                    .GetConstructor(Type())
                    .Invoke(_value.Select(v => (object)v).ToArray());
        } 
    }
}
