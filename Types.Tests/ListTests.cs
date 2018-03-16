using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.List;
using Types.Core.Union;
using Types.Tests.Common;

namespace Types.Tests
{

    public class ListMonadA : TList<Number>.T<ListMonadA>
    {
        public ListMonadA(params Number[] numbers) 
            : this(numbers.ToList())
        {
                
        }
        public ListMonadA(IEnumerable<Number> value) : base(value)
        {
        }
    }

    public class ListMonadB : TList<String>.T<ListMonadB>
    {
        public ListMonadB(params string[] strs) 
            : this(strs.ToList())
        {
            
        }
        public ListMonadB(IEnumerable<string> value) : base(value)
        {
        }
    }

    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void List_monad()
        {
            var r = new ListMonadA(
                new Number(1),
                new Number(2),
                new Number(3)
            )
           .Bind(
                n => new ListMonadB(
                        $"n: {n} - 4",
                        $"n: {n} - 4",
                        $"n: {n} - 4"
                     )
            );
            var g = 5;
        }
    }
}
