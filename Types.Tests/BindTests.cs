using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.Union;
using Types.Tests.Common;
using Types.Core.Union.Kind2;
using static Types.Core.Either.Functor;
using static Types.Core.Either.Monad;

namespace Types.Tests
{

    [TestClass]
    public class BindTests
    {
        [TestMethod]
        public void Either_Bind_must_be_same_type_as_param()
        {
            Assert
                .IsTrue(
                    new MonadA(new A())
                        .Bind(a => new MonadB(new B())) is MonadB
                 );
        }
    }
}
