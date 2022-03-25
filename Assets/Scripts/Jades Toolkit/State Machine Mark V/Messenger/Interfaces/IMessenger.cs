using System;
namespace JadesToolkit.StateOfLife.Messenger
{
    public interface IMessenger<T> where T : Delegate
    {
        void AddListener(T value);
        void RemoveListener(T value);
        void Clear();
    }
}