using Types.Core.Monads;
using Types.Tests.Common;

namespace Types.Tests
{
    public class MonadB : TEither<B, Error>.M<MonadB>
    {
        public MonadB(B value) : base(value)
        {
        }

        public MonadB(Error value) : base(value)
        {
        }
    }
}
