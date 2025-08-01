using Godot;
using SlimeProjectCamion.Types;
using System;

public partial class PlayerJumpState : PlayerState
{

    private Player player;

    public override void _Ready()
    {
        player = (Player)stateMachine.Owner;
    }

    public override void Enter()
    {
        player.Jump();
    }

    public override void PhysicsUpdate(double delta)
    {
        if (Mathf.IsEqualApprox(player.LinearVelocity.Y, 0))
        {
            stateMachine.ChangeState(StatesType.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
