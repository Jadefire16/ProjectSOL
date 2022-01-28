using JadesToolkit.Experimental.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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