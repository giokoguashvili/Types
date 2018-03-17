namespace Types.Core.New.Either
{
    public class Either<TLeft, TRight> : TEither<TLeft, TRight>.IParent<Either<TLeft, TRight>>
        where TLeft : class
        where TRight : class
    {
        public Either(TLeft left) : base(left)
        {
        }

        public Either(TRight right) : base(right)
        {
        }
    }

    public class Error
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }

    public class Right<T> : Either<Error, T>
        where T : class
    {
        public Right(T right) : base(right)
        {
        }
    }

    public class Left<TRight> : Either<Error, TRight>
        where TRight : class
    {
        public Left(Error left) : base(left)
        {
        }
    }

}
