extends PlayerState


func Enter(_msg := {}):
	stateMachine.GetThisPlayer().Jump()
	stateMachine.ChangeState("Fall")
