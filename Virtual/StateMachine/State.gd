extends Node
class_name State


var stateMachine: StateMachine


func Enter(_msg := {}) -> void:
	pass

func Update(_delta: float) -> void:
	pass

func PhysicsUpdate(_delta: float) -> void:
	pass

func Exit() -> void:
	pass
