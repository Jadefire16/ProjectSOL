using JadesToolkit.StateOfLife.Chronos.Updating;
using JadesToolkit.StateOfLife.Transitioning;
using JadesToolkit.StateOfLife.Collections;
using JadesToolkit.StateOfLife.Core;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private Transform t;
    private StateMachine stateMachine;
    

    private void Awake()
    {
        InitializeStates();
        stateMachine.Initialize();
    }

    void InitializeStates()
    {
        var updateHandler = GetComponent<IUpdateServiceProvider>();
        var transitionResolver = new TransitionResolver();
        var s1 = new StateOne(t);
        var s2 = new StateTwo(t);
        var s3 = new StateThree(t);

        var layeredStateCollection = new LayeredStateCollection();
        var stateCollection = new StateCollection(s1);

        var t1 = new DemoTransition(() => Input.GetMouseButtonDown(0), s2);
        var t2 = new DemoTransition(() => Input.GetMouseButtonDown(1), s3);
        var t3 = new DemoTransition(() => Input.GetMouseButtonDown(0), s1);

        stateCollection.AddTransition<StateOne>(t1);
        stateCollection.AddTransition<StateTwo>(t2);
        stateCollection.AddTransition<StateThree>(t3);

        layeredStateCollection.AddStateCollection(stateCollection);

        stateMachine = new StateMachine(updateHandler, transitionResolver, layeredStateCollection);
    }

    private void Update()
    {
        stateMachine.Tick();
    }

}
