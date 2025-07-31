using Godot;
using SlimeProjectCamion.Types;
using System;

public partial class PlayerIdleState : State
{
    private Vector2 move = Vector2.Zero;


    public override void Enter()
    {
        move = Vector2.Zero;
    }

    public override void UserInput(InputEvent @event)
    {
        //if (@event.IsActionPressed("LMB")) return;

        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Y = Input.GetAxis("ui_up", "ui_down");
    }

    public override void Update(double delta)
    {
        if (move == Vector2.Zero) return;
        stateMachine.ChangeState(StatesType.Move);
    }

}
