using JadesToolkit.StateOfLife.Core;
namespace JadesToolkit.StateOfLife.Transitioning
{ 
    public interface ITransition
    {
        bool ConditionMet();
        IState GetTransitionState();
    }
}