using Types.Core.New.Either;

namespace Types.Tests.Common
{
    public class MonadC : TEither<Error, Number>.IParent<MonadC>
    {
        public MonadC(Error left) : base(left)
        {
        }

        public MonadC(Number right) : base(right)
        {
        }
    }
}
