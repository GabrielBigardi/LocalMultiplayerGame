using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity) { }

    public override void Tick()
    {
        base.Tick();

        _playerEntity.JumpCheck();
        _playerEntity.Shoot();
        _playerEntity.FlipBasedOnInput(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();

        _playerEntity.SetVelocityX(_playerEntity.core.playerInputHandler.mov.x * (_playerEntity.core.playerInputHandler.holdingRun ? _playerEntity.data.airSpeed * _playerEntity.data.runSpeedMultiplier : _playerEntity.data.airSpeed) * Time.deltaTime);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _playerEntity.currentState = "Air";
        _playerEntity.PlayAnimation("Air");

        _playerEntity.core.currentInWaterTime = 0f;
        _playerEntity.core.currentDrowningTime = 0f;

    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
