using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.Core.Either;
using Types.Tests.Common;

namespace Types.Tests.Monads.Core
{ 

    [TestClass]
    public class EitherMonadTests
    {
        [TestMethod]
        public void Either_Monad()
        {
            Assert
                .AreEqual(
                    "30",
                    new EitherX(new Number(27))
                        .Bind(n => new EitherX(new Number(n.Value + 3)))
                        .Match(
                            l => l.Message,
                            r => r.Value.ToString()
                        )
                );

            Assert
                .AreEqual(
                    "30",
                    new EitherX(new Number(27))
                        .Fmap(a => new Number(a.Value + 3))
                        .Match(
                            l => l.Message,
                            r => r.Value.ToString()
                        )
                );
            
        }
    }
}
