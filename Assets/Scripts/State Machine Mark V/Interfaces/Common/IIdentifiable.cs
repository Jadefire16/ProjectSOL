namespace JadesToolkit.Experimental.StateMachine
{
    public interface IIdentifiable<T>
    {
        T Identifier { get; }
        T GetIdentifier();
        bool Matches(T other);
    }
}