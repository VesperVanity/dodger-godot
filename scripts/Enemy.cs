using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private CollisionShape2D collision;
	private RectangleShape2D rect = new RectangleShape2D();
	float random_gravity = 0;
	float random_size = 0;
	public override void _Ready()
	{
		collision = GetNode<CollisionShape2D>("CollisionShape2D");
		random_gravity = rng.RandfRange(0.3f, 0.9f);
		GravityScale = random_gravity;
		random_size = rng.RandfRange(20.0f, 100.0f);
		collision.Shape = rect;
		rect.Size = new Vector2(random_size, random_size);
	}
}
