namespace Monads.Core.Either
{
    public class Either<TLeft, TRight> : TEither<TLeft, TRight>.P<Either<TLeft, TRight>>
    {
        public Either(TLeft t0) : base(t0)
        {
        }

        public Either(TRight t1) : base(t1)
        {
        }
    }
}