using System.Collections.Generic;

namespace JadesToolkit.StateOfLife.Core
{
    public interface IResolvable<T>
    {
        T Resolve(IEnumerable<T> objs);
    }
}