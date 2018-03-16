namespace Types.Core.Monads
{
    public class Factory<TResult, TInput>
    {
        private readonly object _self;
        private readonly TInput _value;

        public Factory(object self, TInput value)
        {
            _self = self;
            _value = value;
        }
        public TResult Instance()
        {
            return (TResult)_self
                    .GetType()
                    .GetConstructor(new[] { typeof(TInput) })
                    .Invoke(new object[] { _value });
        } 
    }
}
