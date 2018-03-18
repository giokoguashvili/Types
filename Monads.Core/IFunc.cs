namespace Monads.Core
{
    public interface IFunc<in TInput, out TResult>
    {
        TResult Execute(TInput value);
    }
}