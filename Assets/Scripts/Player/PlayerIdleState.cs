using UnityEngine;

public class PlayerIdleState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public PlayerIdleState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
		_stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        _playerEntity.JumpCheck();
        _playerEntity.Shoot();
    }
	
    public void FixedTick()
    {

    }

    public void OnEnter()
    {
        _playerEntity.currentState = "Idle";
        _playerEntity.SetVelocityX(0f);
        _playerEntity.PlayAnimation("Idle");
        _playerEntity.core.doubleJump = false;
    }

    public void OnExit()
    {

    }
}
