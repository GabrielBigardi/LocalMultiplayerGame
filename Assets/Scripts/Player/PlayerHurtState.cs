using UnityEngine;

public class PlayerHurtState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly PlayerEntity _playerEntity;

    public PlayerHurtState(StateMachine stateMachine, PlayerEntity playerEntity)
    {
        _stateMachine = stateMachine;
        _playerEntity = playerEntity;
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {

    }

    public void OnEnter()
    {
        _playerEntity.currentState = "Hurt";
        _playerEntity.PlayAnimation("Hurt");
        _playerEntity.SetFrozen(true);

        //Debug.Log($"{_playerEntity.core.rgbd.velocity.x} - {_playerEntity.core.rgbd.velocity.y}");

        //var normalizedInverseVel = -_playerEntity.core.rgbd.velocity.normalized;
        //_playerEntity.core.rgbd.velocity = new Vector2(Mathf.Abs(_playerEntity.core.rgbd.velocity.x) > 0.01 ? normalizedInverseVel.x * 6f : 0f,
        //                                               Mathf.Abs(_playerEntity.core.rgbd.velocity.y) > 0.01f ? normalizedInverseVel.y * 6f : 0f);
    }

    public void OnExit()
    {
        _playerEntity.SetFrozen(false);
    }
}
