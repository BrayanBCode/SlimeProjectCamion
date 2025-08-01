using Godot;
using SlimeProjectCamion.Types;
using System;


public partial class PlayerIdleState : PlayerState
{
    private Vector2 move = Vector2.Zero;


    public override void Enter()
    {
        move = Vector2.Zero;
    }

    public override void HandleInput(InputEvent eve)
    {
        if (eve.IsActionPressed("LMB"))
        {
            stateMachine.ChangeState(StatesType.Jump);
            GD.Print("YUMP");
        }

        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Y = Input.GetAxis("ui_up", "ui_down");
    }

    public override void Update(double delta)
    {
        if (move == Vector2.Zero) return;
        stateMachine.ChangeState(StatesType.Move);
    }

}
