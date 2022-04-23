using JadesToolkit.StateOfLife.Chronos.Updating;

namespace JadesToolkit.StateOfLife.Core
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
    }
}