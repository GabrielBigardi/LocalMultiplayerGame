using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterState : IState
{
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerEntity _playerEntity;

    public PlayerWaterState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
        _stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }

    public virtual void Tick()
    {
        _playerEntity.Shoot();
    }

    public virtual void FixedTick()
    {

    }

    public virtual void OnEnter()
    {
        _playerEntity.core.defaultCollider.gameObject.SetActive(false);
        _playerEntity.core.waterCollider.gameObject.SetActive(true);
        _playerEntity.core.rgbd.gravityScale = 0f;
    }

    public virtual void OnExit()
    {
        _playerEntity.core.defaultCollider.gameObject.SetActive(true);
        _playerEntity.core.waterCollider.gameObject.SetActive(false);
        _playerEntity.core.rgbd.gravityScale = 1f;

        _playerEntity.SetVelocityY(_playerEntity.data.jumpForce);
        _playerEntity.core.rgbd.gravityScale = 1f;
    }
}
