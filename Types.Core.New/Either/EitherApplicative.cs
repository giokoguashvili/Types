using System;
using System.Collections.Generic;
using System.Text;

namespace Types.Core.New.Either
{
    public abstract class EitherApplicative<TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public class TParent<A>
            : TApplicative<TRight>.THead<TLeft>.IParent<A>
        {
            private readonly TUnion<TLeft, TRight> _functor;

            public TParent(TUnion<TLeft, TRight> functor)
            {
                _functor = functor;
            }

            public A Apply<A1, T2>(TEither<TLeft, IFunc<TRight, T2>>.IParent<A1> app)
                where T2 : class
            {
                return app.Match(
                        (l) => new Factory<A, TLeft>(l).Instance(),
                        (r) => _functor
                            .Match(
                                (ll) => 
                                    new Factory<A, TLeft>(ll).Instance(),
                                (rr) => 
                                    new Factory<A, T2>(r.Run(rr)).Instance()
                            )
                    );
            }

            public A Prune(TRight value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
