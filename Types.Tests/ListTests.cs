using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var g = new Listt<Number>(Enumerable.Range(1, 100).Select(i => new Number(i)))
                .Bind(a => new Listt<Number>(Enumerable.Range(1, 3).Select(i => new Number(a.Value + i))));
            var x = 6;
        }
    }
}
