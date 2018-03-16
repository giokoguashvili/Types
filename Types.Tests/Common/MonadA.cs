using Types.Core.Either;
using Types.Core.Monads;
using Types.Tests.Common;

namespace Types.Tests
{
    public class MonadA : TEither<A, Error>.T<MonadA>
    {
        public MonadA(A value) : base(value)
        {
        }

        public MonadA(Error value) : base(value)
        {
        }
    }
}
