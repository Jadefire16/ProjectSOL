using System.Collections.Generic;

namespace JadesToolkit.Experimental.StateMachine
{
    public interface ILayeredStateCollection
    {
        void AddStateCollection(IStateCollection collection);
        void InsertStateCollection(IStateCollection collection, int desiredPos);
        bool RemoveCollection(IStateCollection collection);
        void RemoveCollectionAt(int index);
        IStateCollection GetCollectionAt(int index);
        IEnumerable<IStateCollection> GetStateCollections();
    }
}