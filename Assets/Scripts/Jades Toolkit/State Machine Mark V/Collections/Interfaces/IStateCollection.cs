using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Core;
using System.Collections.Generic;
using System;

namespace JadesToolkit.StateOfLife.Collections
{
    public interface IStateCollection : IIdentifiable<long>
    {
        IState EntryState { get; }
        void AddStateOfType<T>() where T : IState;
        void AddTransition<T>(ITransition transition) where T : IState;
        void AddTranstions<T>(IEnumerable<ITransition> transitions) where T : IState;
        IReadOnlyList<ITransition> GetCurrentTransitions<T>() where T : IState;
        IReadOnlyList<ITransition> GetCurrentTransitions(Type type);
    }
}