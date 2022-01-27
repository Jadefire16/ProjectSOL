using System.Collections.Generic;

namespace JadesToolkit.Experimental.StateMachine
{
    public interface IResolvable<T>
    {
        T Resolve(IEnumerable<T> objs);
    }
}