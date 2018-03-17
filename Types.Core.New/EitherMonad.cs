using System;
using Types.Core.New;

namespace Types.Core.Either2
{
    public class EitherMonad<TLeft, TRight>
        : Monad<TRight>.IParent<Either<TLeft, TRight>>
        where TLeft : class
        where TRight : class
    {
        private readonly IUnion<TLeft, TRight> _union;

        public EitherMonad(IUnion<TLeft, TRight> union)
        {
            _union = union;
        }

        public M1 Bind<M1, T1>(Func<TRight, Monad<T1>.IParent<M1>> m)
            where M1 : Monad<T1>.IParent<M1>
            where T1 : class
        {
            return _union
                       .Match(
                           (l) => new Factory<M1, TLeft>(l).Instance(),
                           (r) => new Factory<M1, T1>(m(r).Value()).Instance()
                       );
        }

        public TRight Value()
        {
            return _union.Match(e => (TRight)null, (r) => r);
        }



        //public M1 Bind<M1, T3>(Func<TRight, Monad<TLeft, T3>.IParent<M1>> m)
        //    where M1 : Monad<TLeft, T3>.IParent<M1>
        //{
        //    return _union
        //            .Match(
        //                (l) => new Factory<M1, TLeft>(l).Instance(),
        //                (r) => new Factory<M1, T3>(m(r).Value()).Instance()
        //            );
        //}

    }
}
