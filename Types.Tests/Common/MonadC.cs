using Types.Core.New.Either;

namespace Types.Tests.Common
{
    public class MonadC : TEither<ErrorA, Number>.IParent<MonadC>
    {
        public MonadC(ErrorA left) : base(left)
        {
        }

        public MonadC(Number right) : base(right)
        {
        }
    }
}
