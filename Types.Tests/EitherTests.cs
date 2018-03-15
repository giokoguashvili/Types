using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.Monads;
using Types.Core.Union;
using Types.Tests.Common;

namespace Types.Tests
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Either_Bind_with_result_and_error()
        {
            Assert
                .AreEqual(
                    new Number(27 + 3).ToString(),
                    new EitherM<Number, Error>(
                        new Number(27)
                    )
                    .Bind(
                        a => new EitherM<Number, Error>(
                                  new Number(a.Value + 3)
                             )
                    )
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );

            Assert
                .AreEqual(
                    "Error",
                    new EitherM<Number, Error>(
                        new Error("Error")
                    )
                    .Bind(
                        a => new EitherM<Number, Error>(
                                  new Number(a.Value + 3)
                             )
                    )
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );
        }
    }
}
