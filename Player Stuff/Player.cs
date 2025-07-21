using Godot;
using System;

public partial class Player : RigidBody3D
{
    [Export]
    private float speed = 5000f;
    [Export]
    private float horizontalJumpStrength = 2500f;
    [Export]
    private float verticalJumpStrength = 500f;

    private Vector3 move = Vector3.Zero;
    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Z = Input.GetAxis("ui_up", "ui_down");
        move = move.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        Vector3 mov = Utilities.MultipyVector(move, speed * delta);
        ApplyCentralForce(mov);
    }

    public void Click(Node camera, InputEvent inputEvent, Vector3 event_position, Vector3 normal, int shapeIDX)
    {
        if (!inputEvent.IsActionPressed("LMB"))
        {
            return;
        }

        Vector3 dir = Position.DirectionTo(event_position);
        Vector3 push = Utilities.MultipyVector(dir, horizontalJumpStrength);
        push.Y = verticalJumpStrength;

        ApplyCentralForce(push);
    }
}
