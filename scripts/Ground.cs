using Godot;
using System;

public partial class Ground : Area2D
{
	private void _on_body_entered(RigidBody2D body)
	{
		if(body is Enemy)
		{
			body.QueueFree();
		}
	}

}
