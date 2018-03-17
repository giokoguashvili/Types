using System.Collections.Generic;
using System.Linq;
using Types.Core.List;

namespace Types.Tests.Common
{
    public class ListMonadA : TList<Number>.ParentType<ListMonadA>
    {
        public ListMonadA(params Number[] numbers)
            : this(numbers.ToList())
        {

        }
        public ListMonadA(IEnumerable<Number> value) : base(value)
        {
        }
    }
}
