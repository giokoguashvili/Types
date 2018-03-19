using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.Core.Either;
using Monads.Core.List;
using Monads.Core.List.Type;
using Types.Tests.Common;
using Qweex.Unions;

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

            Assert
                .AreEqual(
                    "30",
                    new ApplicativeA(
                            a => new Number(a.Value + 3)
                    )
                    .Apply(
                            new EitherX(
                                new Number(27)
                            )
                    )
                    .Match(
                        l => l.Message,
                        r => r.Value.ToString()
                    )
                );

            var g = new ListM<Number>(
                        new Number(27), 
                        new Number(3)
                    ).Fmap(n => n.Value.ToString());

        }
    }
}
