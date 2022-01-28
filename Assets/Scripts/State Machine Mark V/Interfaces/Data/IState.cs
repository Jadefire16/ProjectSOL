using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JadesToolkit.Experimental.StateMachine
{
    public interface IState : IUpdateResolver 
    {
        void OnEnter();
        void OnExit();
    }
}