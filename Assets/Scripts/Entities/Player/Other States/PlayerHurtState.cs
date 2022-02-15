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
        _playerEntity.core.anim.AnimationEnded += CheckTransitions;
    }

    public override void OnExit()
    {
        base.OnExit();

        _playerEntity.SetFrozen(false);
        _playerEntity.core.anim.AnimationEnded -= CheckTransitions;
    }

    void CheckTransitions()
    {
        Debug.Log("Checking Transitions");
        if (_playerEntity.IsGrounded)
        {
            if (_playerEntity.core.playerInputHandler.mov.x == 0f)
            {
                _stateMachine.SetState(_playerEntity.IdleState);
            }
            else
            {
                _stateMachine.SetState(_playerEntity.WalkState);
            }
        }
        else
        {
            _stateMachine.SetState(_playerEntity.AirState);
        }
    }
}
