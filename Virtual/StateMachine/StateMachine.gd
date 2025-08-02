extends Node
class_name StateMachine


@export var printChange: = true
@export var initialState: State
#var Player[] players

var currentState: State

func  _ready() -> void:
	assert(is_instance_valid(initialState))

	currentState = initialState
	currentState.Enter()
	for state: State in self.get_children():
		state.stateMachine = self

func _process(delta: float) -> void:
	currentState.Update(delta)

func _physics_process(delta: float) -> void:
	currentState.PhysicsUpdate(delta)

func ChangeState(stateName: String) -> void:
	var targetState: State = get_node(stateName)
	if (is_instance_valid(targetState)):
		currentState.Exit()
		currentState = targetState
		print_debug(self.name + " changed state to: " + currentState.name)
		currentState.Enter()
		return;
	print_debug("Che flaco le erraste al nombre del state")
	
