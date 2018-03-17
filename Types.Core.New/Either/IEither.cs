using Types.Core.New;

namespace Types.Core.Either2
{
    public interface IEither<TParent, TLeft, TRight> :
               IUnion<TLeft, TRight>,
               TMonad<TRight>.THead<TLeft>.IParent<TParent>
        where TRight : class
        where TLeft : class
    {

    }
}
