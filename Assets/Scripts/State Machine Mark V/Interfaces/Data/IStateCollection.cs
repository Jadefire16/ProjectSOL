using System;
using System.Collections.Generic;

namespace JadesToolkit.Experimental.StateMachine
{
    public interface IStateCollection : IIdentifiable<long>
    {
        IState EntryState { get; }
        void AddStateOfType<T>() where T : IState;
        void AddTransition<T>(ITransition transition) where T : IState;
        void AddTranstions<T>(IEnumerable<ITransition> transitions) where T : IState;
        IEnumerable<ITransition> GetCurrentTransitions<T>() where T : IState;
        IEnumerable<ITransition> GetCurrentTransitions(Type type);
    }
}