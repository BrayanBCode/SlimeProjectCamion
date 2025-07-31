using Godot;


public partial class Player : RigidBody3D
{

    [Export] private float speed = 2500f;
    [Export] private float horizontalJumpStrength = 500f;
    [Export] private float verticalJumpStrength = 500f;

    private bool isJumping = false;
    private bool isGrounded = false;
    private Vector3 lastKnownMousePosition = Vector3.Zero;
    private Vector3 move;

    //Events keyboard
    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsActionPressed("LMB") && isGrounded) OnClick();

        move = Vector3.Zero;

        move.X = Input.GetAxis("ui_left", "ui_right");
        move.Z = Input.GetAxis("ui_up", "ui_down");
        move = move.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        ApplyGravity(delta);
    }

    public void MouseInput(Node camera, InputEvent inputEvent, Vector3 event_position, Vector3 normal, int shapeIDX)
    {
        lastKnownMousePosition = event_position;
    }

    public void OnClick()
    {
        Vector3 dir = Position.DirectionTo(lastKnownMousePosition);
        Vector3 push = Utilities.MultipyVector(dir, horizontalJumpStrength);
        push.Y = verticalJumpStrength;

        ApplyCentralForce(push);
    }

    // TODO: Buscar una gravedad ideal y y valores como la gente para el salto ta !!potente!! y no toma bien la posicion de evento click

    private void ApplyGravity(double delta)
    {
        // Movimiento solo si estás en el piso
        if (isGrounded)
        {
            Vector3 mov = move * speed * (float)delta;
            ApplyForce(mov);
        }

        // Revisar si está en el piso
        isGrounded = Mathf.IsEqualApprox(LinearVelocity.Y, 0, 0.1f);
    }



}


