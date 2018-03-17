using Types.Core.Either;

namespace Types.Tests.Common
{
    public class MonadB : TEither<B, ErrorA>.ParentType<MonadB>
    {
        public MonadB(B value) : base(value)
        {
        }

        public MonadB(ErrorA value) : base(value)
        {
        }
    }
}
