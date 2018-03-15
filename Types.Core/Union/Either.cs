using System;
using Types.Core.Union.Kind2;
using static Types.Core.Union.UnionExts;

namespace Types.Core.Union
{
    public class Either<TLeft, TRight> : IUnion<TLeft, TRight>,
        IMonad<Either<TLeft, TRight>, TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public Either(Func<Either<TLeft, TRight>> factory) : base(factory) { }
        public Either(TLeft t1) : base(t1) {}
        public Either(TRight t2) : base(t2) {}

        public M1 Bind<M1, T2>(Func<TLeft, IMonad<M1, T2, TRight>> m)
            where M1 : IMonad<M1, T2, TRight>
            where T2 : class
        {
            return (M1)UnionExts.Match(this, m, (e) => (IMonad<M1, T2, TRight>)new Either<T2, TRight>(e));
        }
    }
}
