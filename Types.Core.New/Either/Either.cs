using System.Collections.Generic;
using System.Text;
using Types.Core.New;

namespace Types.Core.Either2
{
    public class Either<TLeft, TRight>
        : TEither<TLeft, TRight>.IParent<Either<TLeft, TRight>>
        where TLeft : class
        where TRight : class
    {
        public Either(TLeft left) : this(new Union<TLeft, TRight>(left))
        {
        }

        public Either(TRight right) : this(new Union<TLeft, TRight>(right))
        {

        }
        public Either(IUnion<TLeft, TRight> union)
            : this(union, new EitherMonad<TLeft, TRight>(union)) { }
        public Either(IUnion<TLeft, TRight> union, Monad<TRight>.IParent<Either<TLeft, TRight>> eitherMonad)
            : base(union, eitherMonad)
        {
        }
    }
}
