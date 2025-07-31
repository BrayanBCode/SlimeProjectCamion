using Godot;
using Godot.Collections;


[Tool, GlobalClass]
public partial class State : Node
{
    public StateMachine stateMachine = null;

    public virtual void Enter()
    {
        return;
    }
    public virtual void Enter(Dictionary msg)
    {
        return;
    }

    public virtual void UserInput(InputEvent @event)
    {
        return;
    }

    public virtual void Update(double delta)
    {
        return;
    }

    public virtual void PhysicsUpdate(double delta)
    {
        return;
    }

    public virtual void Exit()
    {
        return;
    }
}
