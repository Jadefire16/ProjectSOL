using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace JadesToolkit.StateOfLife.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The Transition Resolution Provider type</typeparam>
    /// <typeparam name="S">The Base State Type.<br/>Recommended for a concrete base class/interface for your states such as IState.</typeparam>
    public abstract class StateMachineFrame<T, S> 
        where T : ITransition 
        where S : IState
    {
        protected IUpdateServiceProvider updateService;
        protected ITransitionResolutionProvider<T> transitionResolutionProvider;
        
        protected ILayeredStateCollection layeredStateCollection;
        protected IStateCollection currentStateCollection;

        /// <summary>
        /// Stores the current state.
        /// </summary>
        protected S currentState;

        /// <summary>
        /// This method is to be used as an equivalent to Unity's Start method.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// This method is to be used as an Update function.
        /// </summary>
        public abstract void Tick();

        /// <summary>
        /// A method for transitioning between states.
        /// </summary>
        public abstract void Transition();
    }
}