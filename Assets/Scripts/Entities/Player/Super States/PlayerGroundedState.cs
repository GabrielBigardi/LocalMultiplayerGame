using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity) { }

    public override void Tick()
    {
        base.Tick();

        _playerEntity.JumpCheck();
        _playerEntity.Shoot();

        if (_playerEntity.core.playerInputHandler.jump)
        {
            _stateMachine.SetState(_playerEntity.AirState);
        }
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _playerEntity.core.doubleJump = false;
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
