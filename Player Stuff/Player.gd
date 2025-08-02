extends RigidBody3D
class_name Player

@export var speed: float = 2500
@export var horizontalJumpStrength: float = 500
@export var verticalJumpStrength: float = 500

var isGrounded: bool = false
var lastKnownMousePosition: Vector3 = Vector3.ZERO
var playerID: String = "SlimeCamion"


func MouseInput(_camera: Node, _inputEvent: InputEvent, event_position: Vector3, _normal: Vector3, _shapeIDX: int) -> void:
	lastKnownMousePosition = event_position

func Jump() -> void:
	var dir: Vector3 = self.position.direction_to(lastKnownMousePosition)
	var push: Vector3 = dir * horizontalJumpStrength
	push.y = verticalJumpStrength

	self.apply_central_force(push);

func  Move(move: Vector3, delta: float) -> void:
	if (isGrounded):
		var mov: Vector3 = move * speed * delta
		self.apply_central_force(mov)

	isGrounded = is_zero_approx(self.linear_velocity.y)
