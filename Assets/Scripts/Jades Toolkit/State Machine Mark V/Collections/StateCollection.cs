using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Utility;
using JadesToolkit.StateOfLife.Core;
using System.Collections.Generic;
using System;

namespace JadesToolkit.StateOfLife.Collections
{
    public class StateCollection : IStateCollection
    {
        /// <summary>
        /// <inheritdoc cref="id"/>
        /// </summary>
        public long Identifier => id;
        /// <summary>
        /// <inheritdoc cref="entryState"/>
        /// </summary>
        public IState EntryState => entryState;


        /// <summary>
        /// A collection of unique state entries .
        /// </summary>
        private readonly Dictionary<Type, List<ITransition>> allTransitions;
        /// <summary>
        /// The entry or 'default' state of the collection.
        /// </summary>
        private IState entryState;
        /// <summary>
        /// The identifier of this collection.
        /// </summary>
        /// <remarks>There is a high probability that this is unique, however not guaranteed.</remarks>
        private readonly long id;

        public StateCollection(IState entryState)
        {
            allTransitions = new Dictionary<Type, List<ITransition>>();
            this.entryState = entryState;
            id = Utility.Identifier.GetUniqueIdentifier();
        }

        /// <summary>
        /// <see cref="AddStateOfType{T}(int)"/>
        /// </summary>
        /// <typeparam name="T">Where T implements <see cref="IState"/></typeparam>
        public void AddStateOfType<T>() where T : IState => AddStateOfType<T>();

        /// <summary>
        /// Will initialize an inner collection bound to a key of type <typeparamref name="T"/> if one does not exist.
        /// </summary>
        /// <typeparam name="T">The key as <see cref="Type"/>.</typeparam>
        /// <param name="defaultSize">The default size for the inner collection</param>
        public void AddStateOfType<T>(int defaultSize = 1)
        {
            if (allTransitions.ContainsKey(typeof(T)))
                return;
            allTransitions.Add(typeof(T), new List<ITransition>(defaultSize));
        }

        /// <summary>
        /// Will initialize an inner collection bound to a key of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The key as <see cref="Type"/>.</typeparam>
        /// <param name="defaultSize">The default size for the inner collection</param>
        /// <remarks>Can throw an exception if the key already exists.</remarks>
        private void AddStateOfTypeUnsafe<T>(int defaultSize = 1)
        {
            allTransitions.Add(typeof(T), new List<ITransition>(defaultSize));
        }

        public void AddTransition<T>(ITransition transition, int defaultSize = 1) where T : IState
        {
            var stateType = typeof(T);
            if (!allTransitions.ContainsKey(stateType))
                AddStateOfTypeUnsafe<T>(defaultSize);
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