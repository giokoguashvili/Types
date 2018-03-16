using System;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.List;
using Types.Core.Union;
using Types.Tests.Common;

namespace Types.Tests
{

    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void List_monad()
        {
            Assert
                .AreEqual(
                    "141524253435",
                    new ListMonadA(
                        new Number(1),
                        new Number(2),
                        new Number(3)
                    )
                    .Bind(
                        n => new ListMonadB(
                            $"{n}4",
                            $"{n}5"
                        )
                    ).Aggregate(String.Empty, (prev, next) => prev + next)
                );
        }
    }
}
