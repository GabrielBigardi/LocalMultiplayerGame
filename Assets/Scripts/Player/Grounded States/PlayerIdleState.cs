using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine,playerEntity)
    {

    }
    
    public override void Tick()
    {
        base.Tick();
    }
	
    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _playerEntity.currentState = "Idle";
        _playerEntity.SetVelocityX(0f);
        _playerEntity.PlayAnimation("Idle");
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
