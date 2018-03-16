using Types.Core.Either;

namespace Types.Tests.Common
{
    public class MonadB : TEither<B, Error>.T<MonadB>
    {
        public MonadB(B value) : base(value)
        {
        }

        public MonadB(Error value) : base(value)
        {
        }
    }
}
