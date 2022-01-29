using System;
using System.Collections.Generic;

namespace JadesToolkit.StateOfLife.Collections
{
    public class LayeredStateCollection : ILayeredStateCollection
    {
        private readonly List<IStateCollection> stateCollections;

        public LayeredStateCollection()
        {
            stateCollections = new List<IStateCollection>(1);
        }

        public void AddStateCollection(IStateCollection collection) => stateCollections.Add(collection);
        public void InsertStateCollection(IStateCollection collection, int desiredPos)
        {
            if (desiredPos > stateCollections.Count | desiredPos < 0)
                throw new IndexOutOfRangeException($"The desired position must be greater than zero or one greater than the end index \n Desired Position:{desiredPos}");
            stateCollections.Insert(desiredPos, collection);
        }
        public bool RemoveCollection(IStateCollection collection)
        {
            return stateCollections.Remove(collection);
        }
        public void RemoveCollectionAt(int index)
        {
            if (index > stateCollections.Count | index < 0)
                throw new IndexOutOfRangeException($"The index must not be less than zero or greater than the end index \n Index:{index}");
            stateCollections.RemoveAt(index);
        }
        public IStateCollection GetCollectionAt(int index)
        {
            if (index > stateCollections.Count | index < 0)
                throw new IndexOutOfRangeException($"The index must not be less than zero or greater than the end index \n Index:{index}");
            return stateCollections[index];
        }
        public IEnumerable<IStateCollection> GetStateCollections()
        {
            if (stateCollections.Count >= 1)
            {
                foreach (var collection in stateCollections)
                {
                    yield return collection;
                }
            }
        }
    }
}