namespace Types.Core.Either.Functor
{
    public interface IFunctor<F0, T0, T1>
        where F0 : IFunctor<F0, T0, T1>
        where T0 : class
        where T1 : class
    {
    }
}
