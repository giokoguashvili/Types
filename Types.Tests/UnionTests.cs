using Microsoft.VisualStudio.TestTools.UnitTesting;
using Types.Core.Union;
using Types.Core.Union.Kind2;
using Types.Tests.Common;

namespace Types.Tests
{

    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_match_LeftType_and_RightType()
        {
            var expectedA = typeof(A);
            Assert
                .AreEqual(
                    expectedA,
                    new Union<A, B>(new A())
                        .Match(
                            (a) => expectedA,
                            (b) => typeof(B)
                        )
                );

            var exceptedB = typeof(B);
            Assert
                .AreEqual(
                    exceptedB,
                    new Union<A, B>(new B())
                        .Match(
                            (a) => typeof(A),
                            (b) => exceptedB
                        )
                );
        }
    }
}
