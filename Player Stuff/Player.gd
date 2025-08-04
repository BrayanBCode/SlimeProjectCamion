extends RigidBody3D
class_name Player

@export var speed: float = 2500
@export var maxHorizontalJumpDistance: float = 10.0
@export var maxVerticalJumpClamp: float = 10.0
@export var flyTime: float = 1

@onready var trajectory_parent := $TrajectoryPoints  # Nodo donde se agregarán los puntos (ej: un Node3D vacío)


var isGrounded: bool = false
var lastKnownMousePosition: Vector3 = Vector3.ZERO
var playerID: String = "SlimeCamion"
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")


func _physics_process(_delta: float) -> void:
	isGrounded = is_zero_approx(self.linear_velocity.y)

func MouseInput(_camera: Node, _inputEvent: InputEvent, event_position: Vector3, _normal: Vector3, _shapeIDX: int) -> void:
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


#Si solo usamos esta funcion aca no necesita argumentos
func CalculateParabolicVelocity3D(start: Vector3, end: Vector3):
	var desplazamiento = end - start
	var horizontalDes = Vector3(desplazamiento.x, 0, desplazamiento.z)
	if(horizontalDes.length() > maxHorizontalJumpDistance):
		var dir = start.direction_to(end)
		dir.y = 0
		horizontalDes = dir * maxHorizontalJumpDistance
	var verticalDes = clampf(desplazamiento.y, 0, maxVerticalJumpClamp)
	var modFlyTime = flyTime + (verticalDes/maxVerticalJumpClamp)
	
	var horizontalVel = horizontalDes / modFlyTime
	var verticalVel = (verticalDes + 0.5 * gravity * modFlyTime**2) / modFlyTime
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
