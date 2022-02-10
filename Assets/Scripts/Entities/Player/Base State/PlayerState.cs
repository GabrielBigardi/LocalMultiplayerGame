using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : IState
{
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerEntity _playerEntity;

    public PlayerState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
        _stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }

    public virtual void Tick()
    {

    }

    public virtual void FixedTick()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
}
