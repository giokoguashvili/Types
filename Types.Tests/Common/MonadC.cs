using Types.Core.Either2;
using Types.Tests.Common;

namespace Types.Tests.New
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
