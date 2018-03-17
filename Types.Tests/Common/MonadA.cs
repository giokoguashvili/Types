using Types.Core.Either;

namespace Types.Tests.Common
{
    public class MonadA : TEither<A, ErrorA>.ParentType<MonadA>
    {
        public MonadA(A value) : base(value)
        {
        }

        public MonadA(ErrorA value) : base(value)
        {
        }
    }
}
