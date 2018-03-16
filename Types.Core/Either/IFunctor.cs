using System.Collections.Generic;
using System.Text;

namespace Types.Core.Either
{
    public interface IFunctor<F0, T0, T1>
        where F0 : IFunctor<F0, T0, T1>
        where T0 : class
        where T1 : class
    {
    }
}
