using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(StateMachine stateMachine, PlayerEntity playerEntity) : base(stateMachine, playerEntity) {}

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

        _playerEntity.currentState = "Hurt";
        _playerEntity.PlayAnimation("Hurt");
        _playerEntity.SetFrozen(true);
    }

    public override void OnExit()
    {
        base.OnExit();

        _playerEntity.SetFrozen(false);
    }
}
