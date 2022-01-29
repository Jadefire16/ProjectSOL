namespace JadesToolkit.StateOfLife.Core
{
    public interface IIdentifiable<T> : IIdentifiable
    {
        T Identifier { get; }
        T GetIdentifier();
        bool Matches(T other);
    }
}