using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.New.Either;
using Types.Tests.Common;
using static Types.Core.Either.Functor.Functor;
using static Types.Core.Either.Monad.Monad;

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

            Assert
                .AreEqual(
                    "37",
                    new Right<Number>(new Number(10))
                        .Bind(n => new Right<Number>(new Number(n.Value + 27)))
                        .Match(
                            (l) => l.ToString(),
                            (r) => r.Value.ToString()
                        )
                );
        }
    }
}
