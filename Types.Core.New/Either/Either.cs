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
}
