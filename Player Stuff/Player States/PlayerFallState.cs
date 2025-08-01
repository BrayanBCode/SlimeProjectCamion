using Godot;
using SlimeProjectCamion.Types;
using System;

public partial class PlayerFallState : PlayerState
{
    public override void OnBodyEntered(Node body)
    {
        if (Mathf.IsZeroApprox(stateMachine.GetThisPlayer().LinearVelocity.Y))
        {
            stateMachine.ChangeState(StatesType.Idle);
        }
    }
}
