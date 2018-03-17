using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.New.Union;

namespace Types.Core.New.Either
{
    public abstract class Applicative<TLeft, TRight>
           where TLeft : class
           where TRight : class
    {
        public class TParent<A>
            : TApplicative<TRight>.THead<TLeft>.IParent<A>
        {
            private readonly IUnion<TLeft, TRight> _functor;

            public TParent(IUnion<TLeft, TRight> functor)
            {
                _functor = functor;
            }

            public A Apply<T2>(IUnion<TLeft, IFunc<TRight, T2>> app)
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
                return new Factory<A, TRight>(value).Instance();
            }
        }
    }
}
