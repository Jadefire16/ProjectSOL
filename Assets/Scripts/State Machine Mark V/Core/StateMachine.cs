using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JadesToolkit.Experimental.StateMachine
{
    public class StateMachine
    {
        private readonly IUpdateServiceProvider updateService;
        private readonly ITransitionResolutionProvider transitionResolverService;
        private readonly ILayeredStateCollection layeredStateCollection;
        private readonly IStateCollection currentStateCollection;

        private IState currentState;

        private Type StateType => currentState.GetType();
        
        public StateMachine(IUpdateServiceProvider updateService, ITransitionResolutionProvider transitionResolverService, ILayeredStateCollection layeredStateCollection)
        {
            this.updateService = updateService;
            this.transitionResolverService = transitionResolverService;
            this.layeredStateCollection = layeredStateCollection;

            currentStateCollection = layeredStateCollection.GetCollectionAt(0);
            currentState = currentStateCollection.EntryState;
        }

        public void Tick()
        {
            var transition = transitionResolverService.GetFirstValidTransition(currentStateCollection.GetCurrentTransitions(StateType));
            if (transition == null)
                return;
            Transition(transition);
        }

        private void Transition(ITransition transition)
        {
            currentState.OnExit();
            currentState = transition.GetTransitionState();
            currentState.OnEnter();
            updateService.SetUpdateResolver(currentState.GetUpdateResolver());
        }
    }
}
