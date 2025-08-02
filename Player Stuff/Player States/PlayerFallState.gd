extends PlayerState



func _ready() -> void:
	animationName = ""

func OnBodyEntered(_body: Node) -> void:
	if (is_zero_approx(stateMachine.GetThisPlayer().linear_velocity.y)):
		stateMachine.ChangeState("Idle")
	stateMachine.GetThisPlayer().linear_velocity = Vector3.ZERO

func PhysicsUpdate(delta: float):
	var player = (stateMachine as PlayerStateMachine).GetThisPlayer()
	print("Modulo: ", sqrt(player.linear_velocity.x**2 * player.linear_velocity.z**2))
