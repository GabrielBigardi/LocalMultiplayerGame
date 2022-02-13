using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity) { }

    public override void Tick()
    {
        base.Tick();

        _playerEntity.core.spriteRenderer.transform.Rotate(new Vector3(0f, 0f, 500f * Time.deltaTime));
        if(_playerEntity.core.spriteRenderer.transform.localScale.x > 0f)
        {
            _playerEntity.core.spriteRenderer.transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }
        else
        {
            _stateMachine.SetState(_playerEntity.IdleState);
        }
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _playerEntity.PlayAnimation("Death");
        _playerEntity.SetFrozen(true);
        _playerEntity.HideNameText();
        _playerEntity.HideHealthBar();
    }

    public override void OnExit()
    {
        base.OnExit();

        _playerEntity.SetFrozen(false);
        _playerEntity.ShowNameText();
        _playerEntity.ShowHealthBar();
        _playerEntity.core.spriteRenderer.transform.localScale = Vector3.one;
        _playerEntity.core.spriteRenderer.transform.localRotation = Quaternion.Euler(Vector3.zero);
        _playerEntity.Heal(_playerEntity.core.playerHealth.maxHealth);
        _playerEntity.transform.position = new Vector3(-6.16f, -3.5f, 0f);
    }
}
