using System.Collections.Generic;

namespace Types.Core.List
{
    public class Listt<T1> : TList<T1>.T<Listt<T1>>
        where T1 : class
    {
        public Listt(IEnumerable<T1> value) : base(value)
        {
        }
    }
}
