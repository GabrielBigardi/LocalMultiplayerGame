using UnityEngine;

public class PlayerWaterIdleState : PlayerWaterState
{
    public PlayerWaterIdleState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity)
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

        Debug.Log($"Water Idle - Drowning: {drowning}");
        _playerEntity.currentState = "Water Idle";
        _playerEntity.PlayAnimation("WaterIdle");

        _playerEntity.SetVelocityX(0);
        _playerEntity.SetVelocityY(0);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
