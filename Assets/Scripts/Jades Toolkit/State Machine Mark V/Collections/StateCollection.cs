using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Utility;
using JadesToolkit.StateOfLife.Core;
using System.Collections.Generic;
using System;

namespace JadesToolkit.StateOfLife.Collections
{
    //The runtime state layer, edit time will be converted into one of these
    public class StateCollection : IStateCollection
    {
        public long Identifier => id;

        public IState EntryState => entryState;

        private readonly Dictionary<Type, List<ITransition>> allTransitions;
        private IState entryState;
        private readonly long id;

        public StateCollection(IState entryState)
        {
            allTransitions = new Dictionary<Type, List<ITransition>>();
            this.entryState = entryState;
            id = IdentifierHelper.GetUniqueIdentifier();
        }

        public void AddStateOfType<T>() where T : IState => AddStateOfType<T>(2);
        public void AddStateOfType<T>(int defaultSize = 2)
        {
            if (allTransitions.ContainsKey(typeof(T)))
                return;
            allTransitions.Add(typeof(T), new List<ITransition>(defaultSize));
        }
        public void AddTransition<T>(ITransition transition) where T : IState
        {
            var stateType = typeof(T);
            if (!allTransitions.ContainsKey(stateType))
                allTransitions.Add(stateType, new List<ITransition>(2));
            if (!allTransitions[stateType].Contains(transition))
                allTransitions[stateType].Add(transition);
        }
        public void AddTranstions<T>(IEnumerable<ITransition> transitions) where T : IState
        {
            var stateType = typeof(T);
            if (!allTransitions.TryGetValue(stateType, out List<ITransition> list))
                allTransitions.Add(stateType, list = new List<ITransition>(2));
            foreach (var transition in transitions)
            {
                if (!list.Contains(transition))
                    list.Add(transition);
            }
        }
        public IReadOnlyList<ITransition> GetCurrentTransitions<T>() where T : IState
        {
            return allTransitions[typeof(T)];
        }

        public long GetIdentifier() => id;

        public IReadOnlyList<ITransition> GetCurrentTransitions(Type type)
        {
            return allTransitions[type];
        }
        public bool Matches(long other) => id.Equals(other);
        public bool Matches(object other)
        {
            if (!(other is long otherID))
                return false;
            return Matches(otherID);
        }
    }
}