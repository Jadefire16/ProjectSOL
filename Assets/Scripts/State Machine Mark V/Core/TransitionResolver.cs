using System.Collections.Generic;

namespace JadesToolkit.Experimental.StateMachine
{
    public class TransitionResolver : ITransitionResolutionProvider
    {
        public IEnumerable<ITransition> GetAllValidTransitions(IEnumerable<ITransition> transitions)
        {
            foreach (var transition in transitions)
            {
                if (transition.ConditionMet())
                    yield return transition;
            }
        }
        public ITransition GetFirstValidTransition(IEnumerable<ITransition> transitions)
        {
            foreach (var transition in transitions)
            {
                if (transition.ConditionMet())
                    return transition;
            }
            return null;
        }
        public ITransition GetValidTransition(IEnumerable<ITransition> transitions, IResolvable<ITransition> resolver) // resolver will take a collection and output the best suited result, specified by the user
        {
            return resolver.Resolve(transitions);
        }
    }
}