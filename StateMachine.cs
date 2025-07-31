using Godot;
using System;


[Tool, GlobalClass]
public partial class StateMachine : Node
{
    [Export] public bool printChange = true;
    [Export] public State initalState;
    public State currentState;

    public override void _Ready()
    {
        base._Ready();

        if (!IsInstanceValid(initalState)) GD.PrintErr("TODO MAL FLACO");

        currentState = initalState;
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

    public void ChangeState(string stateName)
    {
        // foreach (State targetState in GetChildren())
        // {
        //     if (targetState.Name != stateName) continue;

        //     currentState.Exit();

        //     currentState = targetState;
        //     GD.Print(Name + " changed state to: " + currentState.Name);
        //     currentState.Enter();

        //     return;
        // }

        State targetState = GetNode<State>(stateName);
        if (IsInstanceValid(targetState))
        {
            currentState.Exit();
            currentState = targetState;
            currentState.Enter();
            GD.Print(Name + " changed state to: " + currentState.Name);
            return;
        }

        GD.Print("Che flaco le erraste al nombre del state");
    }
}
