using Monads.Core.Either;
using Monads.Core.Either.Type;
using Types.Tests.Common;

namespace Types.Tests.Monads.Core
{
    public class EitherX : TEither<ErrorA, Number>.P<EitherX>
    {
        public EitherX(ErrorA value) : base(value)
        {
        }

        public EitherX(Number value) : base(value)
        {
        }
    }
}
