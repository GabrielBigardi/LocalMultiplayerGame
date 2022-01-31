using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterState : IState
{
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerEntity _playerEntity;

    protected float drowningDelay = 1f;
    protected float currentDrowningDelay = 0f;
    protected float currentWaterTime = 0f;

    protected bool drowning = false;

    public PlayerWaterState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
        _stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }

    public virtual void Tick()
    {
        _playerEntity.Shoot();

        currentWaterTime += Time.deltaTime;
        
        if(currentWaterTime >= 5f)
        {
            drowning = true;
        }
        
        if (drowning)
        {
            currentDrowningDelay += Time.deltaTime;
            if(currentDrowningDelay >= drowningDelay)
            {
                _playerEntity.TakeDamage(5);
                currentDrowningDelay = 0f;
            }
        }
    }

    public virtual void FixedTick()
    {

    }

    public virtual void OnEnter()
    {
        _playerEntity.core.defaultCollider.gameObject.SetActive(false);
        _playerEntity.core.waterCollider.gameObject.SetActive(true);
        _playerEntity.core.rgbd.gravityScale = 0f;

        currentWaterTime = 0f;
        currentDrowningDelay = 0f;
        drowning = false;
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
