using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Core;
using UnityEngine;
public class StateThree : IState
{
    public IUpdateResolver GetUpdateResolver() => this;
    Transform t;
    public StateThree(Transform t)
    {
        this.t = t;
    }

    public void OnEnter()
    {
        Debug.Log("State three entered!");
    }

    public void OnExit()
    {
        Debug.Log("State three exited!");
    }

    public void Resolve<T>() where T : IStateCycle
    {
        var type = typeof(T);
        if (!(type is ILateCycle))
            return;
        LateUpdate();
    }

    void LateUpdate()
    {
        t.position += (new Vector3(0, 0, 1) * Time.deltaTime);
    }

}
