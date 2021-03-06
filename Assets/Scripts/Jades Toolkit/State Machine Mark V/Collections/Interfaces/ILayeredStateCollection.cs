using System.Collections.Generic;

namespace JadesToolkit.StateOfLife.Collections
{
    public interface ILayeredStateCollection
    {
        void AddStateCollection(IStateCollection collection);
        void InsertStateCollection(IStateCollection collection, int desiredPos);
        bool RemoveCollection(IStateCollection collection);
        void RemoveCollectionAt(int index);
        IStateCollection GetCollectionAt(int index);
        bool TryGetCollectionAt(int index, out IStateCollection collection);
        IEnumerable<IStateCollection> GetStateCollections();
    }
}