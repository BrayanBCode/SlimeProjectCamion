extends PlayerState



func _ready() -> void:
	animationName = ""

func OnBodyEntered(_body: Node) -> void:
	if (is_zero_approx(stateMachine.GetThisPlayer().linear_velocity.y)):
		stateMachine.ChangeState("Idle")
