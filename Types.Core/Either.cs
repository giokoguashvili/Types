namespace Types.Core.Monads
{
    public class Either<T0, T1> : TEither<T0, T1>.M<Either<T0, T1>>
        where T0 : class
        where T1 : class
    {
        public Either() : base((T0)null)
        {

        }
        public Either(T0 value) : base(value)
        {
        }

        public Either(T1 value) : base(value)
        {
        }
    }
}
