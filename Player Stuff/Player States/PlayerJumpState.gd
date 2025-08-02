extends PlayerState



func _ready() -> void:
	animationName = ""

func Enter(_msg := {}):
	stateMachine.GetThisPlayer().linear_velocity = Vector3.ZERO
	stateMachine.GetThisPlayer().Jump()
	stateMachine.ChangeState("Fall")
