using UnityEngine;

public class PlayerWaterSwimState : PlayerWaterState
{
    public PlayerWaterSwimState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity)
    {

    }

    public override void Tick()
    {
        base.Tick();

        _playerEntity.FlipBasedOnInput(false);
    }

    public override void FixedTick()
    {
        base.Tick();

        _playerEntity.core.rgbd.velocity = _playerEntity.data.waterSpeed * Time.deltaTime * (new Vector2(_playerEntity.core.playerInputHandler.mov.x, _playerEntity.core.playerInputHandler.mov.y).normalized);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _playerEntity.currentState = "Water Swim";
        _playerEntity.PlayAnimation("WaterSwim");
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
