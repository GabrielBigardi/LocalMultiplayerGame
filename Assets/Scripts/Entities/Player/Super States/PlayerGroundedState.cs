using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : IState
{
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerEntity _playerEntity;

    public PlayerGroundedState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
        _stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }

    public virtual void Tick()
    {
        _playerEntity.JumpCheck();
        _playerEntity.Shoot();

        if (_playerEntity.core.playerInputHandler.jump)
        {
            _stateMachine.SetState(_playerEntity.AirState);
        }
    }

    public virtual void FixedTick()
    {

    }

    public virtual void OnEnter()
    {
        _playerEntity.core.doubleJump = false;
    }

    public virtual void OnExit()
    {

    }
}
