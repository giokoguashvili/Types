using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public class EitherMonad<TLeft, TRight>
        : TMonad<TRight>.IParent<Either<TLeft, TRight>>
        where TLeft : class
        where TRight : class
    {
        private readonly IUnion<TLeft, TRight> _union;

        public EitherMonad(IUnion<TLeft, TRight> union)
        {
            _union = union;
        }

        public M1 Bind<M1, T1>(Func<TRight, TMonad<T1>.IParent<M1>> m)
            where M1 : TMonad<T1>.IParent<M1>
            where T1 : class
        {
            return _union
                       .Match(
                           (l) => new Factory<M1, TLeft>(l).Instance(),
                           (r) => m(r).Bind(a => new Factory<M1, T1>(a).Instance()) 
                       );
        }
    }
}
