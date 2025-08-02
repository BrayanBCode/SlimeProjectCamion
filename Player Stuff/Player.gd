extends RigidBody3D
class_name Player

@export var speed: float = 2500
@export var horizontalJumpStrength: float = 500
@export var verticalJumpStrength: float = 500
@export var flyTime: float = 1

@onready var trajectory_parent := $TrajectoryPoints  # Nodo donde se agregarán los puntos (ej: un Node3D vacío)


var isGrounded: bool = false
var lastKnownMousePosition: Vector3 = Vector3.ZERO
var playerID: String = "SlimeCamion"
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")


func MouseInput(camera: Node, inputEvent: InputEvent, event_position: Vector3, normal: Vector3, shapeIDX: int) -> void:
	#print(event_position)
	lastKnownMousePosition = event_position

func Jump() -> void:
	

	var JumpImpulse = CalculateParabolicVelocity3D(
			self.global_position,
			lastKnownMousePosition
		)
		
	draw_trajectory(self.global_position, JumpImpulse)
	print("JumpImpulse: ", JumpImpulse)
	apply_central_impulse(JumpImpulse * mass)

func Move(move: Vector3, delta: float) -> void:
	if (isGrounded):
		var mov: Vector3 = move * speed * delta
		self.apply_central_force(mov)

	isGrounded = is_zero_approx(self.linear_velocity.y)


func CalculateParabolicVelocity3D(start: Vector3, end: Vector3):
	var desplazamiento = end - start
	var horizontalDes = Vector3(desplazamiento.x, 0, desplazamiento.z)
	var verticalDes = desplazamiento.y
	
	var horizontalVel = horizontalDes / flyTime
	var verticalVel = (verticalDes + 0.5 * gravity * flyTime**2) / flyTime
	return horizontalVel + Vector3.UP * verticalVel


func draw_trajectory(start: Vector3, velocity: Vector3, steps := 30, time_step := 0.1):
	
	# Limpia puntos anteriores
	for child in trajectory_parent.get_children():
		child.queue_free()

	var t := 0.0
	for i in steps:
		var pos = start + (velocity * t) + Vector3(0, -gravity * 0.5, 0) * t * t

		var point = MeshInstance3D.new()
		point.mesh = SphereMesh.new()
		point.scale = Vector3.ONE * 0.5
		point.position = pos
		
		var mat = StandardMaterial3D.new()
		mat.albedo_color = Color(0, 1, 0)  # Naranja (RGB)
		point.material_override = mat
		
		trajectory_parent.add_child(point)
		
		t += time_step
