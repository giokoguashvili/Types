using System;
using System.Collections.Generic;
using System.Linq;
using Types.Core.List;

namespace Types.Tests.Common
{
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
}
