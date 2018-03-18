using System;
using Monads.Core;
using Monads.Core.Either;
using Monads.Core.Either.Type;
using Monads.Core.Union;
using Types.Tests.Common;

namespace Types.Tests.Monads.Core
{
    public class ApplicativeA : TEither<ErrorA>.Func<Number, Number>
    {
        public ApplicativeA(Func<Number, Number> func)
            : this(new F<Number, Number>(func))
        {

        }
        public ApplicativeA(Func<TUnion<ErrorA, IFunc<Number, Number>>> factory) : base(factory)
        {
        }

        public ApplicativeA(ErrorA value) : base(value)
        {
        }

        public ApplicativeA(IFunc<Number, Number> value) : base(value)
        {
        }
    }
}