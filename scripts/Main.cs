using Godot;
using System;

public partial class Main : Node2D
{
	private Label score_label;
	private Timer score_timer;
	private Node2D enemy_container;
	private Timer spawn_enemy_timer;
	private PackedScene enemy_scene;
	private RigidBody2D enemy_instance;
	private Control restart_ui_container;

	public override void _Ready()
	{
		enemy_scene = ResourceLoader.Load<PackedScene>("res://scenes/enemy.tscn");
		score_label = GetNode<Label>("GUI/gui_container/score_label");
		score_timer = GetNode<Timer>("score_timer");
		enemy_container = GetNode<Node2D>("enemy_container");
		spawn_enemy_timer = GetNode<Timer>("spawn_enemy_timer");
		restart_ui_container = GetNode<Control>("GUI/gui_container/restart_ui_container");
	}

	private int score_current = 0;
	private string score_text = "Current Score: ";
	public bool is_player_dead = false;
	public override void _Process(double delta)
	{
		
		if(is_player_dead == false)
		{
			score_label.Text = score_text + score_current;
		}
		else if(is_player_dead)
		{
			spawn_enemy_timer.Stop();
			restart_ui_container.Visible = true;
		}

	}
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private void spawn_enemy()
	{
		float random_enemy_x_position = rng.RandfRange(100, 1820);
		enemy_instance = enemy_scene.Instantiate<RigidBody2D>();
		enemy_container.AddChild(enemy_instance);
		enemy_instance.Position = new Vector2(random_enemy_x_position, 0.0f);
	}
	
	private void _on_spawn_enemy_timer_timeout()
	{
		spawn_enemy();
		float random_timer_time = rng.RandfRange(0.08f, 0.3f);
		spawn_enemy_timer.WaitTime = random_timer_time;
	}

	private void _on_score_timer_timeout()
	{
		score_current++;
	}

	private void _on_restart_button_pressed()
	{
		GetTree().ReloadCurrentScene();
	}

}
