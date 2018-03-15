using System;
using Types.Core.Union;
using Types.Core.Union.Kind2;
using static Types.Core.Union.Unions;

namespace Types.Core.Monads
{
    public class EitherM<TLeft, TRight> : IUnion<TLeft, TRight>,
        IMonad<EitherM<TLeft, TRight>, TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public EitherM(Func<EitherM<TLeft, TRight>> factory) : base(factory) { }
        public EitherM(TLeft t1) : base(t1) {}
        public EitherM(TRight t2) : base(t2) {}

        public M1 Bind<M1, T2>(Func<TLeft, IMonad<M1, T2, TRight>> m)
            where M1 : IMonad<M1, T2, TRight>
            where T2 : class
        {
            return (M1)Unions.Match(this, m, (e) => (IMonad<M1, T2, TRight>)new EitherM<T2, TRight>(e));
        }
    }
}
