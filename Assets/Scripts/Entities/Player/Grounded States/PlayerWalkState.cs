using UnityEngine;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity)
    {

    }
    
    public override void Tick()
    {
        base.Tick();
        _playerEntity.FlipBasedOnInput(false);
    }
	
    public override void FixedTick()
    {
        base.FixedTick();
        _playerEntity.SetVelocityX(_playerEntity.core.playerInputHandler.mov.x * _playerEntity.data.moveSpeed * Time.deltaTime);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _playerEntity.currentState = "Walk";
        _playerEntity.PlayAnimation("Walk");
        _playerEntity.core.doubleJump = false;
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
