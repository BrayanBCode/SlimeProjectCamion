using Godot;
using SlimeProjectCamion.Types;
using System;

public partial class PlayerMoveState : PlayerState
{
    private Vector3 move;

    public override void Enter()
    {
        move = Vector3.Zero;
    }

    public override void UserInput(InputEvent @event)
    {
        //if (@event.IsActionPressed("LMB")) return;

        if (@event.IsActionPressed("LMB"))
        {
            stateMachine.ChangeState(StatesType.Jump);

        }

    }

    // public override void PhysicsUpdate(double delta)
    // {
    //     move.X = Input.GetAxis("ui_left", "ui_right");
    //     move.Z = Input.GetAxis("ui_up", "ui_down");
    //     move = move.Normalized();
    //     Player player = (PlayerStateMachine)stateMachine;
    //     player.Move(move, delta);

    //     if (player.LinearVelocity == Vector3.Zero && move == Vector3.Zero)
    //     {
    //         stateMachine.ChangeState(StatesType.Idle);
    //     }
    // }
}