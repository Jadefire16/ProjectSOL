using JadesToolkit.StateOfLife.Core;
using System.Collections.Generic;

namespace JadesToolkit.StateOfLife.Transitioning
{
    public interface ITransitionResolutionProvider
    {
        IEnumerable<ITransition> GetAllValidTransitions(IEnumerable<ITransition> transitions);
        ITransition GetFirstValidTransition(IEnumerable<ITransition> transitions);
        ITransition GetValidTransition(IEnumerable<ITransition> transitions, IResolvable<ITransition> resolver);
    }
}