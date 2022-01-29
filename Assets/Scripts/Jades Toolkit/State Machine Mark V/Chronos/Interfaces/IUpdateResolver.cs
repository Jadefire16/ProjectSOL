namespace JadesToolkit.StateOfLife.Chronos.Updating
{
    public interface IUpdateResolver
    {
        /// <summary>
        /// Determines which update message the user wishes to call.
        /// </summary>
        /// <remarks>
        /// This is used to resolve issues where users may wish to have multiple update calls on their states.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        void Resolve<T>() where T : IStateCycle;
        IUpdateResolver GetUpdateResolver();
    }
}