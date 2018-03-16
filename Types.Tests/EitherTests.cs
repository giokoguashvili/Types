using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.Monads;
using Types.Core.Union;
using Types.Tests.Common;
using Types.Core.Union.Kind2;

namespace Types.Tests
{

    public class NumberMonad : IEither<Number, Error>.M<NumberMonad>
    {
        public NumberMonad(Number value) : base(value)
        {
        }

        public NumberMonad(Error value) : base(value)
        {
        }
        public NumberMonad() : base((Error)null)
        {

        }
    }
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Either_Bind_with_result_and_error()
        {
            //var g = new NumberMonad()
            //        .Bind(a => new NumberMonad())
            //var g = new NumberMonad().Retrun(new Number(27));
            Assert
                .AreEqual(
                    new Number(27 + 3).ToString(),
                    new Either<Number, Error>(
                        new Number(27)
                    )
                    .Bind(
                        a => new Either<Number, Error>(
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
                    new Either<Number, Error>(
                        new Error("Error")
                    )
                    .Bind(
                        a => new Either<Number, Error>(
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
                    new Either<Number, Error>(
                        new Error("Error")
                    )
                    .Fmap<Either<Number, Error>, Number>(number => new Number(number.Value + 3))
                    .Match(
                        (sum) => sum.ToString(),
                        (e) => e.Message
                    )
                );
        }
    }
}
