using System.Collections.Generic;

namespace Types.Core.List
{
    public abstract class EList<T1> : List<T1>
    {
        protected EList(IEnumerable<T1> elems) : base(elems)
        {
                
        }
    }
}
