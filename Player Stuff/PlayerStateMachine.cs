using Godot;
using System;


public partial class PlayerStateMachine : StateMachine
{
    public new PlayerState currentState;

    public override void _Ready()
    {
        base._Ready();

        if (!IsInstanceValid(initialState)) GD.PrintErr("TODO MAL FLACO");

        currentState = (PlayerState)initialState;
        base.currentState.Enter();
        foreach (PlayerState state in GetChildren())
        {
            state.stateMachine = this;
        }
    }

    public Player GetThisPlayer() { return (Player)this.Owner; } // by copilot: Pegate un tiro si no te gusta

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);
        
        currentState.HandleInput(@event);
    }

    public void OnBodyEntered(Node body)
    {
        currentState.OnBodyEntered(body);
    }
}
