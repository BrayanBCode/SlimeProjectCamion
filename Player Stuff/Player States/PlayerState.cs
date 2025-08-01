using Godot;
using System;


[Tool, GlobalClass]
public partial class PlayerState : State
{
    public new PlayerStateMachine stateMachine;

    public virtual void HandleInput(InputEvent eve)
    {
        return;
    }

    public virtual void OnBodyEntered(Node body)
    {
        return;
    }
}
