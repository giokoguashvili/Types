namespace Types.Core.New
{
    public interface IFunc<in T0, out T1>
    {
        T1 Run(T0 value);
    }
}
