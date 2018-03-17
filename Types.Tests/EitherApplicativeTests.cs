﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Types.Core.Either2;
using Types.Core.New;
using Types.Tests.Common;
using Types.Tests.New;

namespace Types.Tests
{
    public class FuncA : IFunc<Number, Number>
    {
        private readonly Func<Number, Number> _f;
        public FuncA(Func<Number, Number> f)
        {
            _f = f;
        }
        public Number Run(Number value)
        {
            return _f(value);
        }
    }

    public class EitherA : TEither<Error, IFunc<Number, Number>>.IParent<EitherA>
    {
        public EitherA(Func<Number, Number> f) 
            : this(new FuncA(f))
        {

        }
        public EitherA(Error left) : base(left)
        {
        }

        public EitherA(FuncA right) : base(right)
        {
        }
    }

    [TestClass]
    public class EitherApplicativeTests
    {
        [TestMethod]
        public void Either_Bind_must_be_same_type_as_param()
        {
            
             Assert
                .AreEqual(
                    "30",
                     new MonadC(new Number(27))
                        .Apply(new EitherA(a => new Number(a.Value +3)))
                        .Match(
                            (e) => e.ToString(),
                            (r) => r.Value.ToString()
                         )
                 );
        }
    }
}
