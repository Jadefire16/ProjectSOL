namespace JadesToolkit.StateOfLife.Chronos.Updating
{
    public interface IUpdateServiceProvider
    {
        IUpdateResolver UpdateResolver { get; }
        IUpdateResolver GetUpdateResolver();
        void SetUpdateResolver(IUpdateResolver resolver);
    }
}