using Types.Core.Either;

namespace Types.Tests.Common
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
