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
        _playerEntity.FlipBasedOnInput(false);
        _playerEntity.Shoot();

        _playerEntity.core.currentInWaterTime += Time.deltaTime;
        if (_playerEntity.core.currentInWaterTime >= 4f)
        {
            _playerEntity.core.currentDrowningTime += Time.deltaTime;
            if (_playerEntity.core.currentDrowningTime >= 1f)
            {
                _playerEntity.TakeDamage(10, false);
                _playerEntity.core.currentDrowningTime = 0f;
            }
        }
    }

    public virtual void FixedTick()
    {
        _playerEntity.core.rgbd.velocity = (_playerEntity.core.playerInputHandler.holdingRun ? _playerEntity.data.waterSpeed * _playerEntity.data.runSpeedMultiplier : _playerEntity.data.waterSpeed) * Time.deltaTime * (new Vector2(_playerEntity.core.playerInputHandler.mov.x, _playerEntity.core.playerInputHandler.mov.y).normalized);
        if(_playerEntity.core.rgbd.velocity == Vector2.zero)
        {
            if(_playerEntity.core.anim.CurrentAnimation.Name != "WaterIdle")
            {
                _playerEntity.PlayAnimation("WaterIdle");
            }
        }
        else
        {
            if (_playerEntity.core.anim.CurrentAnimation.Name != "WaterSwim")
            {
                _playerEntity.PlayAnimation("WaterSwim");
            }
        }
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

        _playerEntity.core.currentInWaterTime = 0f;
        _playerEntity.core.currentDrowningTime = 0f;

    }
}
