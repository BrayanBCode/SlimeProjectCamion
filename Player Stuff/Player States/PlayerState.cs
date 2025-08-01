using Godot;
using System;

[Tool, GlobalClass]
public partial class PlayerState : State
{

    public Player getThisPlayer()
    {
        return (Player)this.Owner;
    }
}
