using System.Collections.Generic;

namespace JadesToolkit.StateOfLife.Transitioning
{
    public interface ITransitionResolutionProvider<TValue> : ITransitionResolutionProvider where TValue : ITransition
    {
        IEnumerable<TValue> GetValidTransitions<TEnemurable>(IEnumerable<TValue> transitions) where TEnemurable : class, IEnumerable<TValue>;
        IList<TValue> GetValidTransitions<TList>(in IList<TValue> transitions) where TList : class, IList<TValue>, IEnumerable<TValue>, new();
        bool TryGetValidTransitions<TList>(in IList<TValue> transitions, IList<TValue> validTransitions) where TList : class, IList<TValue>, IEnumerable<TValue>;
    }
}