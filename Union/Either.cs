using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Union
{
    public abstract class Either<TLeft, TRight> : Union<TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        protected Either(Func<Either<TLeft, TRight>> factory) : base(factory) { }
        protected Either(TLeft t1) : base(t1)
        {
        }

        protected Either(TRight t2) : base(t2)
        {
        }
    }
}
