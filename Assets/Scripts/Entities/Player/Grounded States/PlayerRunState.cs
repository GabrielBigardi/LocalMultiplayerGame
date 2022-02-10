using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity) { }
    
    public override void Tick()
    {
        base.Tick();

        _playerEntity.FlipBasedOnInput(false);
    }
	
    public override void FixedTick()
    {
        base.FixedTick();

        _playerEntity.SetVelocityX(_playerEntity.core.playerInputHandler.mov.x * (_playerEntity.data.moveSpeed * _playerEntity.data.runSpeedMultiplier) * Time.deltaTime);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _playerEntity.currentState = "Run";
        _playerEntity.PlayAnimation("Run");
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
