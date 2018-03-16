namespace Types.Core.Union
{
    public interface IUnion
    {
        object Value();
    }

    public interface IUnion<T0, T1> : IUnion
    {
    }

    public interface IUnion<T0> : IUnion
    {
    }
}
