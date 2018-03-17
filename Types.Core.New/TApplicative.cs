using Types.Core.New.Either;
using Types.Core.New.Union;

namespace Types.Core.New
{
    public abstract class TApplicative<T0>
        where T0 : class
    {
        public abstract class THead<TH>
            where TH : class
        {
            public interface IParent<out A0>
            {
                A0 Prune(T0 value);
                A0 Apply<T2>(IUnion<TH, IFunc<T0, T2>> app)
                    where T2 : class;
            }
        }
    }
}
