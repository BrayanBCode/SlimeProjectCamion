extends PlayerState



var move: Vector3 = Vector3.ZERO

func HandleInput(input: InputEvent):
	if (input.is_action_pressed("LMB")):
		stateMachine.ChangeState("Jump")

func Update(_delta: float):
	move.x = Input.get_axis("ui_left", "ui_right")
	move.z = Input.get_axis("ui_up", "ui_down")
	move = move.normalized()

func PhysicsUpdate(delta: float):
	var player: Player = stateMachine.GetThisPlayer()
	player.Move(move, delta)

	if (player.linear_velocity == Vector3.ZERO && move == Vector3.ZERO):
		stateMachine.ChangeState("Idle")

func Exit():
	move = Vector3.ZERO

