using Godot;
using System;


public partial class PlayerStateMachine : StateMachine
{

    private Player player;

    public override void _Ready()
    {
        base._Ready();

        if (!IsInstanceValid(initalState)) GD.PrintErr("TODO MAL FLACO");

        currentState = initalState;
        currentState.Enter();
        foreach (PlayerState state in GetChildren())
        {
            state.stateMachine = this;
        }
    }

    public Player getPlayer() { return (Player)this.Owner; } // by copilot: Pegate un tiro si no te gusta

    public override void _Input(InputEvent @event)
    {
        currentState.UserInput(@event);
    }
}
