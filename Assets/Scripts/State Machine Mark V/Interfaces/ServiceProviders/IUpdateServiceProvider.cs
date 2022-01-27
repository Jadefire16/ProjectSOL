namespace JadesToolkit.Experimental.StateMachine
{
    public interface IUpdateServiceProvider
    {
        IUpdateResolver UpdateResolver { get; }
        IUpdateResolver GetUpdateResolver();
        void SetUpdateResolver(IUpdateResolver resolver);
    }
}