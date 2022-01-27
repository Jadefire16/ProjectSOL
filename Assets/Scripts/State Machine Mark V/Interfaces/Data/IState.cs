using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JadesToolkit.Experimental.StateMachine
{
    public interface IState : IIdentifiable<long>, IUpdateResolver 
    {
        void OnEnter();
        void OnExit();
        void OnDestroy();
    }
}