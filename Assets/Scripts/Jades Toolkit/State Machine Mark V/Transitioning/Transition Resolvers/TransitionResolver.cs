using JadesToolkit.StateOfLife.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JadesToolkit.StateOfLife.Transitioning
{
    public class TransitionResolver : ITransitionResolutionProvider<ITransition>
    {
        IEnumerable<ITransition> ITransitionResolutionProvider<ITransition>.GetValidTransitions<TEnemurable>(IEnumerable<ITransition> transitions)
        {
            var _ = transitions as TEnemurable;
            foreach (var transition in _)
            {
                if (transition.ConditionMet())
                    yield return transition;
            }
        }
        IList<ITransition> ITransitionResolutionProvider<ITransition>.GetValidTransitions<TList>(in IList<ITransition> transitions)
        {
            var list = new TList();
            foreach (var transition in transitions)
            {
                if (transition.ConditionMet())
                    list.Add(transition);
            }
            return list;
        }
        bool ITransitionResolutionProvider<ITransition>.TryGetValidTransitions<TList>(in IList<ITransition> transitions, IList<ITransition> validTransitions)
        {
            for (int i = 0; i < transitions.Count; i++)
            {
                if (transitions[i].ConditionMet())
                    validTransitions.Add(transitions[i]);
            }
            return validTransitions.Count > 0;
        }
    }
}
/// <summary>
/// Fetches all the transitions which are currently valid.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="transitions"></param>
/// <remarks>This method does make allocations which must be freed by GC.</remarks>
/// <returns></returns>
//public IEnumerable<T> GetValidTransitions<T>(IEnumerable<T> transitions) where T : ITransition
//{
//    foreach (var transition in transitions)
//    {
//        if (transition.ConditionMet())
//            yield return transition;
//    }
//}

//public List<T> GetValidTransitions<T>(List<T> transitions) where T : ITransition
//{
//    var list = new List<T>(transitions.Count);
//    foreach (var transition in transitions)
//    {
//        if (transition.ConditionMet())
//            list.Add(transition);
//    }
//    return list;
//}
//public bool TryGetValidTransitions<T>(in List<T> transitions, ref List<T> validTransitions) where T : ITransition
//{          
//    foreach (var transition in transitions)
//    {
//        if (transition.ConditionMet())
//            validTransitions.Add(transition);
//    }
//    return validTransitions.Count <= 0;
//}

//public T[] GetValidTransitions<T>(T[] transitions) where T : ITransition
//{
//    var arr = new T[transitions.Length];
//    for (int i = 0, j = 0; i < transitions.Length; i++)
//    {
//        if (!transitions[i].ConditionMet())
//            continue;
//        arr[j] = transitions[i];
//        j++;
//    }
//    return arr;
//}

//public bool TryGetValidTransitions<T>(in T[] transitions, ref T[] validTransitions) where T : ITransition
//{
//    bool retValue = false;
//    for (int i = 0, j = 0; i < transitions.Length; i++)
//    {
//        if (!transitions[i].ConditionMet())
//            continue;
//        validTransitions[j] = transitions[i];
//        retValue = true;
//        j++;
//    }
//    return retValue;
//}



//public TList GetValidTransitions<TList, TValue>(in IList<TValue> transitions)
//{
//    var list = new TList();
//    foreach (var transition in transitions)
//    {
//        if (transition.ConditionMet())
//            list.Add(transition);
//    }
//    return list;
//}