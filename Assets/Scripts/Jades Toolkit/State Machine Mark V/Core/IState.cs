using JadesToolkit.StateOfLife.Chronos.Updating;

namespace JadesToolkit.StateOfLife.Core
{
    public interface IState : IUpdateResolver 
    {
        void OnEnter();
        void OnExit();
    }
}