using Godot;
using System;


[Tool, GlobalClass]
public partial class StateMachine : Node
{
    [Export] public bool printChange = true;
    [Export] public State initialState;
    private Player[] players;

    public State currentState;

    public override void _Ready()
    {
        base._Ready();

        if (!IsInstanceValid(initialState)) GD.PrintErr("TODO MAL FLACO");

        currentState = (PlayerState)initialState;
        currentState.Enter();
        foreach (State state in GetChildren())
        {
            state.stateMachine = this;
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        currentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        currentState.PhysicsUpdate(delta);
    }

    public virtual void ChangeState(string stateName)
    {
        State targetState = GetNode<State>(stateName);
        if (IsInstanceValid(targetState))
        {
            currentState.Exit();
            currentState = (PlayerState)targetState;
            GD.Print(Name + " changed state to: " + currentState.Name);
            currentState.Enter();
            
            return;
        }

        GD.Print("Che flaco le erraste al nombre del state");
    }
}
