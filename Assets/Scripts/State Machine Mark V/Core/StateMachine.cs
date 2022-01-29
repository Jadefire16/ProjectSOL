using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Collections;
using UnityEngine;
using System;

namespace JadesToolkit.StateOfLife.Core
{
    public class StateMachine
    {
        private readonly IUpdateServiceProvider updateService;
        private readonly ITransitionResolutionProvider transitionResolverService;
        private readonly ILayeredStateCollection layeredStateCollection;

        private IStateCollection currentStateCollection;
        private IState currentState;

        private Type StateType => currentState.GetType();
        
        public StateMachine(IUpdateServiceProvider updateService, ITransitionResolutionProvider transitionResolverService, ILayeredStateCollection layeredStateCollection)
        {
            this.updateService = updateService;
            this.transitionResolverService = transitionResolverService;
            this.layeredStateCollection = layeredStateCollection;
        }

        public void Initialize()
        {
            currentStateCollection = layeredStateCollection.GetCollectionAt(0);
            currentState = currentStateCollection.EntryState;
            updateService.SetUpdateResolver(currentState);
            currentState.OnEnter();
        }

        public void Tick()
        {
            Debug.Log($"State type is currently {StateType.Name}\nCurrent state collection is null? {currentStateCollection == null} \nTransition Resolver service is null? {transitionResolverService == null} ");
            Debug.Log($"What is this returning? {currentStateCollection.GetCurrentTransitions(StateType) == null}");
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
            updateService.SetUpdateResolver(currentState);
        }
    }
}
