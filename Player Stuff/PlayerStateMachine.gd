extends StateMachine
class_name PlayerStateMachine


func GetThisPlayer() -> Player: return self.owner as Player

func _unhandled_input(event: InputEvent) -> void:        
	currentState.HandleInput(event)

func OnBodyEntered(body: Node) -> void:
	currentState.OnBodyEntered(body)
