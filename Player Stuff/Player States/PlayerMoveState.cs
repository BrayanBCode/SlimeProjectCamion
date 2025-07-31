using Godot;
using System;

public partial class PlayerMoveState : State
{
    private Vector3 move;

    public override void Enter()
    {
        move = Vector3.Zero;
    }


    public override void UserInput(InputEvent @event)
    {
        //if (@event.IsActionPressed("LMB")) return;

    
        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Z = Input.GetAxis("ui_up", "ui_down");
        move = move.Normalized();
    }

    public override void PhysicsUpdate(double delta)
    {
        Player player = (Player)stateMachine.Owner;
        player.Move(move, delta);

        if (player.LinearVelocity == Vector3.Zero && move == Vector3.Zero)
        {
            stateMachine.ChangeState("Idle");
        }
    }
}