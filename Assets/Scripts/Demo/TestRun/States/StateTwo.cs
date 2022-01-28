using JadesToolkit.Experimental.StateMachine;
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

    public void Resolve<T>() where T : IStateUpdate
    {
        var type = typeof(T);
        if (!(type is IUpdate))
            return;
        Update();
    }

    void Update()
    {
        t.position += (new Vector3(0, 1, 0) * Time.deltaTime);
    }
}
