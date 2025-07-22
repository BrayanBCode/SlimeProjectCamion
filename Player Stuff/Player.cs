using Godot;


public partial class Player : RigidBody3D
{

    [Export] private float speed = 2500f;
    [Export] private float horizontalJumpStrength = 500f;
    [Export] private float verticalJumpStrength = 500f;

    private bool isJumping = false;
    private bool isGrounded = false;
    private Vector3 move = Vector3.Zero;

    //Events keyboard
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

        ApplyGravity(delta);
    }


    public void OnClick(Node camera, InputEvent inputEvent, Vector3 event_position, Vector3 normal, int shapeIDX)
    {

        JumpImpulse(inputEvent, event_position);
    }


    /// <summary>
    /// Applies a jump impulse to the player when the left mouse button is pressed.
    /// The player will only jump if they are currently on the ground (LinearVelocity.Y is approximately 0).
    /// The jump direction is determined by the position of the mouse click.
    /// The horizontal jump strength is applied in the direction of the click, and
    /// the vertical jump strength is applied upwards.
    /// </summary>
    /// <remarks>
    /// This method checks if the left mouse button is pressed and if the player is on the ground (LinearVelocity.Y is approximately 0).
    /// If both conditions are met, it calculates the direction from the player's position to the event position,
    /// applies a force in that direction multiplied by the horizontal jump strength,
    /// and sets the vertical component of the force to the vertical jump strength.
    /// The resulting force is then applied to the player's rigid body to create the jump effect.
    /// </remarks>
    /// <param name="inputEvent">The input event that triggered the jump.</param>
    /// <param name="event_position">The position in the world where the mouse click occurred.</param>
    public void JumpImpulse(InputEvent inputEvent, Vector3 event_position)
    {
        if (!inputEvent.IsActionPressed("LMB") || !Mathf.IsEqualApprox(LinearVelocity.Y, 0)) return;

        Vector3 dir = Position.DirectionTo(event_position);
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
            ApplyCentralForce(mov);
        }

        // Revisar si está en el piso
        isGrounded = Mathf.IsEqualApprox(LinearVelocity.Y, 0, 0.1f);
    }



}


