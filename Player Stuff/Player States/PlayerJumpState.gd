extends PlayerState



func _ready() -> void:
	animationName = ""

func Enter(_msg := {}):
	stateMachine.GetThisPlayer().Jump()
	stateMachine.ChangeState("Fall")
