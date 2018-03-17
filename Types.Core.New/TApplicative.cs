using Types.Core.New.Either;

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
                A0 Apply<A1, T2>(TEither<TH, IFunc<T0, T2>>.IParent<A1> app)
                    where T2 : class;
            }
        }
    }
}
