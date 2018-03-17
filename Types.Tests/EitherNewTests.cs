using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.New.Either;
using Types.Tests.Common;

namespace Types.Tests
{

    [TestClass]
    public class EitherNewTests
    {
        [TestMethod]
        public void Either_Bind_must_be_same_type_as_param2()
        {
            Assert
                .AreEqual(
                        "30",
                         new Either<Error, Number>(new Number(27))
                            .Bind(v =>  new MonadC(new Number(27 + 3)))
                            .Match(l => l.ToString(), r => r.Value.ToString())
                 );

            Assert
                .AreEqual(
                        "30",
                         new Either<Error, Number>(new Number(27))
                            .Fmap(a => new Number(a.Value +3))
                            .Match(l => l.ToString(), r => r.Value.ToString())
                 );
            Assert
                .AreEqual(
                        "30",
                         new MonadC(new Number(27))
                            .Fmap(a => new Number(a.Value + 3))
                            .Match(l => l.ToString(), r => r.Value.ToString())
                 );
            Assert
                .AreEqual(
                         new Error(String.Empty).ToString(),
                         new MonadC(new Number(27))
                            .Fmap(a => new Error(String.Empty))
                            .Match(l => l.ToString(), r => r.Value.ToString())
                 );

        }
    }
}
