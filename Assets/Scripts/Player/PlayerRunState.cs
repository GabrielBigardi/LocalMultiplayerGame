using UnityEngine;

public class PlayerRunState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public PlayerRunState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
		_stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }
    
    public void Tick()
    {
        _playerEntity.JumpCheck();
        _playerEntity.Shoot();
        _playerEntity.FlipBasedOnInput(false);
    }
	
    public void FixedTick()
    {
        _playerEntity.SetVelocityX(_playerEntity.core.playerInputHandler.mov.x * (_playerEntity.data.moveSpeed * 2F) * Time.deltaTime);
    }

    public void OnEnter()
    {
        _playerEntity.currentState = "Run";
        _playerEntity.PlayAnimation("Run");
        _playerEntity.core.doubleJump = false;
    }

    public void OnExit()
    {

    }
}
