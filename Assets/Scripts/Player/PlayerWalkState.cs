using UnityEngine;

public class PlayerWalkState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public PlayerWalkState(StateMachine stateMachine, PlayerEntity playerEntity)
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
        _playerEntity.SetVelocityX(_playerEntity.core.playerInputHandler.mov.x * _playerEntity.data.moveSpeed * Time.deltaTime);
    }

    public void OnEnter()
    {
        _playerEntity.currentState = "Walk";
        _playerEntity.PlayAnimation("Walk");
        _playerEntity.core.doubleJump = false;
    }

    public void OnExit()
    {

    }
}
