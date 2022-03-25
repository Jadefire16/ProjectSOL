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
    /// <typeparam name="T"><typeparamref name="T"/> is Transition type</typeparam>
    public abstract class StateMachineBase<T> where T : ITransition
    {
        protected IUpdateServiceProvider updateService;
        protected ITransitionResolutionProvider<T> transitionResolutionProvider;
        
        protected ILayeredStateCollection layeredStateCollection;
        protected IStateCollection currentCollection;

        /// <summary>
        /// This method is to be used as an equivalent to Unity's Start method.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// This method is to be used as an Update function.
        /// </summary>
        public abstract void Tick();

        public abstract void Transition();
    }
}