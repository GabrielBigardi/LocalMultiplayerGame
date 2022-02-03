using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEntity : MonoBehaviour
{
    public GoombaCore core;
    public GoombaData data;

    public StateMachine StateMachine { get; private set; }

    public GoombaIdleState IdleState { get; private set; }
    public GoombaWalkState WalkState { get; private set; }

    private void Start()
    {
        InitializeComponents();
        InitializeStateMachine();
        AddStateMachineTransitions();

        StateMachine.SetState(WalkState);
    }

    private void Update()
    {
        StateMachine.Tick();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedTick();
    }

    public void InitializeComponents()
    {

    }

    public void InitializeStateMachine()
    {
        StateMachine = new StateMachine();

        IdleState = new GoombaIdleState(StateMachine, this);
        WalkState = new GoombaWalkState(StateMachine, this);
    }

    public void AddStateMachineTransitions()
    {

    }
}
