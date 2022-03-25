using JadesToolkit.StateOfLife.Chronos.Updating;

namespace JadesToolkit.StateOfLife.Core
{
    public interface IState : IUpdateResolver 
    {
        void OnEnter();
        void OnExit();
    }
}
// TODO remove the UpdateResolver interface inheritance, it causes a bottle neck in Unity's environment which makes it feel clunky