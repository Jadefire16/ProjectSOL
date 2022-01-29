using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Core;
using System;
public class DemoTransition : ITransition
{
    private readonly Func<bool> condition;
    private readonly IState nextState;
    public DemoTransition(Func<bool> condition, IState nextState)
    {
        this.condition = condition;
        this.nextState = nextState;
    }

    public bool ConditionMet() => condition.Invoke();


    public IState GetTransitionState() => nextState;
}
/// Todo:
/// This feels bad, maybe look into a way to break up this functionality somehow
///