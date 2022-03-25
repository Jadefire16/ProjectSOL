using System.Collections.Generic;
namespace JadesToolkit.StateOfLife.Messenger
{
    public class TestMessenger : IMessenger<UpdateMessage>
    {
        private HashSet<UpdateMessage> listeners;

        public void AddListener(UpdateMessage value) => listeners.Add(value);
        public void RemoveListener(UpdateMessage value) => listeners.Remove(value);
        public void Clear() => listeners = new HashSet<UpdateMessage>();
        public void Invoke()
        {
            foreach (var method in listeners)
                method();
        }
    }
}
/// TODO
/// Concurrent Messages
/// Test for GC allocation, find ways to mitigate cost overall
/// Look into a system to possibly re-use delegates?
/// Look into weak references