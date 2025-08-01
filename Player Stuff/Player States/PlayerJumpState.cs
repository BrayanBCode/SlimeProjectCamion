using Godot;
using SlimeProjectCamion.Types;
using System;

public partial class PlayerJumpState : PlayerState
{
    public override void Enter()
    {
        stateMachine.GetThisPlayer().Jump();
        stateMachine.ChangeState(StatesType.Fall);
    }
}
