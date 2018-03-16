using System.Collections.Generic;

namespace Types.Core.List
{
    public abstract class EnvelopedList<T1> : List<T1>
    {
        protected EnvelopedList(IEnumerable<T1> elems) : base(elems)
        {
                
        }
    }
}
