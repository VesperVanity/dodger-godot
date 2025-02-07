using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : Area2D
{
	private Main main;
	public override void _Ready()
	{
		main = GetParent<Main>();
	}

	public override void _Process(double delta)
	{
		player_movement(delta);
	}

	private void _on_body_entered(RigidBody2D body)
	{
		if(body is Enemy)
		{
			main.is_player_dead = true;
			QueueFree();
		}
	}

	private void player_movement(double delta_time)
	{
		float player_speed = 700.0f;
		float player_movement = player_speed * (float)delta_time;
		if(Input.IsActionPressed("left"))
		{
			Position += new Vector2(-player_movement, 0.0f);
		}
		else if(Input.IsActionPressed("right"))
		{
			Position += new Vector2(player_movement, 0.0f);
		}
	}

}
