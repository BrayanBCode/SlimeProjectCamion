using Godot;
using System;

public partial class Player : RigidBody3D
{
    public float speed = 5000.0f;
    Vector2 move = Vector2.Zero;
    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Y = Input.GetAxis("ui_up", "ui_down");
        move = move.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        Vector2 mousePos = GetViewport().GetMousePosition();

        float deltaFloat = (float)delta * speed;
        Vector3 mov = new(move.X * deltaFloat, 0, move.Y * deltaFloat);
        ApplyCentralForce(mov);
    }

    public void Click(Node camera, InputEvent inputEvent, Vector3 event_position, Vector3 normal, int shapeIDX)
    {
        if (!inputEvent.IsActionPressed("LMB"))
        {
            return;
        }

        Vector3 dir = Position.DirectionTo(event_position);
        dir.Y = 500;
        Vector3 push = dir * new Vector3(2500, 1, 2500);
        ApplyCentralForce(push);
    }
}
