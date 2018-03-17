using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public interface IEither<TParent, TLeft, TRight> :
        TUnion<TLeft, TRight>.IParent<TParent>,
        TMonad<TRight>.THead<TLeft>.IParent<TParent>,
        TFunctor<TRight>.THead<TLeft>.IParent<Either<TLeft, TRight>>
        where TRight : class
        where TLeft : class
    {
    }
}
