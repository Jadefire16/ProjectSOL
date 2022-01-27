using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JadesToolkit.Experimental.StateMachine
{
    public interface ITransition
    {
        bool ConditionMet();
        IState GetTransitionState();
    }
}