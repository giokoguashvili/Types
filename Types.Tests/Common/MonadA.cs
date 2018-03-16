using Types.Core.Monads;
using Types.Tests.Common;

namespace Types.Tests
{
    public class MonadA : IEither<A, Error>.M<MonadA>
    {
        public MonadA() : base((Error)null)
        {
        }

        public MonadA(A value) : base(value)
        {
        }

        public MonadA(Error value) : base(value)
        {
        }
    }
}
