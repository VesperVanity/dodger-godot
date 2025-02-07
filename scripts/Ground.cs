using Godot;
using System;

public partial class Ground : Area2D
{
	
	public override void _Ready()
	{

	}

	
	public override void _Process(double delta)
	{

	}

	private void _on_body_entered(RigidBody2D body)
	{
		if(body is Enemy)
		{
			body.QueueFree();
		}
	}

}
