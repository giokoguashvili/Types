using System.Collections;
using System.Collections.Generic;

namespace Types.Core.List
{
    public abstract class EnvelopedList<T1> : IEnumerable<T1>
    {
        private IEnumerable<T1> _list;
        protected EnvelopedList(params T1[] elems) : this(new List<T1>(elems)) { }
        protected EnvelopedList(IEnumerable<T1> list)
        {
            _list = list;
        }

        public IEnumerator<T1> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
