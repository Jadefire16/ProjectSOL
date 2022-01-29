using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Core;
using UnityEngine;
public class StateTwo : IState
{
    public IUpdateResolver GetUpdateResolver() => this;
    Transform t;
    public StateTwo(Transform t)
    {
        this.t = t;
    }

    public void OnEnter()
    {
        Debug.Log("State two entered!");
    }

    public void OnExit()
    {
        Debug.Log("State two exited!");

    }

    public void Resolve<T>() where T : IStateCycle
    {
        var type = typeof(T);
        if (!(type is IUpdateCycle))
            return;
        Update();
    }

    void Update()
    {
        t.position += (new Vector3(0, 1, 0) * Time.deltaTime);
    }
}
