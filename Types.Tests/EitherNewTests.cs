using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.Either2;
using Types.Tests.Common;

namespace Types.Tests.New
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Either_Bind_must_be_same_type_as_param()
        {
            Assert
                .AreEqual(
                        "30",
                         new Either<Error, Number>(new Number(27))
                            .Bind(v => new Either<Error, Number>(new Number(27 + 3)))
                            .Match(l => l.ToString(), r => r.Value.ToString())
                 );
        }
    }
}
