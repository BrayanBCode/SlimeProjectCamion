extends State
class_name PlayerState


func _ready() -> void:
	await Signal(self.get_parent(), "ready")
	stateMachine = stateMachine as PlayerStateMachine

func HandleInput(_input: InputEvent):
	pass
	
func OnBodyEntered(_body: Node):
	pass
