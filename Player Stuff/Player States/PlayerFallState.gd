extends PlayerState

var playerDamp: float = 0.0


func _ready() -> void:
	animationName = "Jump"


func Enter(_msg := {}):
	#if(stateMachine.GetThisPlayer().isGrounded): stateMachine.ChangeState("Idle")
	playerDamp = stateMachine.GetThisPlayer().linear_damp
	stateMachine.GetThisPlayer().linear_damp = 0.0
	print("damp: ", stateMachine.GetThisPlayer().linear_damp)
func OnBodyEntered(_body: Node) -> void:
	if (is_zero_approx(stateMachine.GetThisPlayer().linear_velocity.y)):
		stateMachine.ChangeState("Idle")
		print_debug("Landed on: ", stateMachine.GetThisPlayer().global_position)
	#stateMachine.GetThisPlayer().linear_velocity = Vector3.ZERO
	
func PhysicsUpdate(delta: float):
	var player = (stateMachine as PlayerStateMachine).GetThisPlayer()
	#print("Modulo: ", sqrt(player.linear_velocity.x**2 * player.linear_velocity.z**2))

func Exit():
	stateMachine.GetThisPlayer().linear_damp = playerDamp
	print("damp: ", stateMachine.GetThisPlayer().linear_damp)
