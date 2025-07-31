using Godot;
using System;

public partial class PlayerStateMachine : StateMachine
{

    public override void _Input(InputEvent @event)
    {
        currentState.UserInput(@event);
    }
}
