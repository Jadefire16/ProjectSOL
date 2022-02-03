using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JadesToolkit.StateOfLife.Core
{
    public class StateMachine
    {
        public Type StateType => currentState.GetType();

        private IUpdateServiceProvider updateService;
        private ITransitionResolutionProvider<ITransition> transitionResolverService;
        private ILayeredStateCollection layeredStateCollection;

        private IStateCollection currentStateCollection;
        private List<ITransition> currentTransitions = new List<ITransition>(16);
        private List<ITransition> validTransitions = new List<ITransition>(16);

        private IState currentState;

        public StateMachine(IUpdateServiceProvider updateService, ITransitionResolutionProvider<ITransition> transitionResolverService, ILayeredStateCollection layeredStateCollection)
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
            currentTransitions = currentStateCollection.GetCurrentTransitions(StateType) as List<ITransition>;
            currentState.OnEnter();
        }

        public void Tick()
        {
            validTransitions.Clear();
            if (!transitionResolverService.TryGetValidTransitions<List<ITransition>>(currentTransitions, validTransitions))
                return;
            Transition(validTransitions[0]);
        }

        private void Transition(ITransition transition)
        {
            currentState.OnExit();
            currentState = transition.GetTransitionState();
            currentTransitions = currentStateCollection.GetCurrentTransitions(StateType) as List<ITransition>;
            currentState.OnEnter();
            updateService.SetUpdateResolver(currentState);
        }
    }
}
