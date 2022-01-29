using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Core;
using UnityEngine;

public class StateOne : IState
{
    public IUpdateResolver GetUpdateResolver() => this;
    Transform t;
    public StateOne(Transform t)
    {
        this.t = t;
    }

    public void OnEnter()
    {
        Debug.Log("State one entered!");
    }

    public void OnExit()
    {
        Debug.Log("State one exited!");

    }

    public void Resolve<T>() where T : IStateCycle
    {
        var type = typeof(T);
        if (!(type is IStateCycle))
            return;
        Update();
    }

    void Update()
    {
        Debug.Log("State one ticked!");
        t.position += (new Vector3(1,0,0) * Time.deltaTime);
    }
}
