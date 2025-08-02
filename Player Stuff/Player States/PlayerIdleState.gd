extends PlayerState



var move: Vector2 = Vector2.ZERO

func _ready() -> void:
	animationName = ""

func Enter(_msg := {}) -> void:
	move = Vector2.ZERO

func HandleInput(input: InputEvent) -> void:
	if (input.is_action_pressed("LMB")):
		stateMachine.ChangeState("Jump")

	move.x = Input.get_axis("ui_left", "ui_right")
	move.y = Input.get_axis("ui_up", "ui_down")

func Update(_delta: float) -> void:
	if (move == Vector2.ZERO): return
	
	stateMachine.ChangeState("Move")
