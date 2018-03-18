using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.Core.Either;
using Monads.Core.Unit;
using Types.Tests.Common;

namespace Types.Tests.Monads.Core
{
    public class ApplicativeA : TEither<ErrorA>.Func<Number, Number>
    {
        public ApplicativeA(Func<Number, Number> func)
            : this(new F<Number, Number>(func))
        {

        }
        public ApplicativeA(Func<TUnion<ErrorA, IFunc<Number, Number>>> factory) : base(factory)
        {
        }

        public ApplicativeA(ErrorA value) : base(value)
        {
        }

        public ApplicativeA(IFunc<Number, Number> value) : base(value)
        {
        }
    }
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
        }
    }
}
