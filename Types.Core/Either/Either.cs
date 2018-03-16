namespace Types.Core.Either
{
    public class Either<T0, T1> : TEither<T0, T1>.T<Either<T0, T1>>
        where T0 : class
        where T1 : class
    {
        public Either(T0 value) : base(value)
        {
        }

        public Either(T1 value) : base(value)
        {
        }
    }
}
