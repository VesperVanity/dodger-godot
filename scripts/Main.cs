using Godot;
using System;

public partial class Main : Node2D
{
	private Label score_label;
	private Timer score_timer;
	public override void _Ready()
	{
		score_label = GetNode<Label>("GUI/gui_container/score_label");
		score_timer = GetNode<Timer>("score_timer");
	}

	private int score_current = 0;
	private string score_text = "Current Score: ";
	public override void _Process(double delta)
	{
		score_label.Text = score_text + score_current;
	}

	private void _on_score_timer_timeout()
	{
		score_current++;
	}

}
