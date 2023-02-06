using Godot;
using System;

public partial class Entity : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}



	public override void _PhysicsProcess(double delta) {
		var vel = Velocity;

		vel += Inert;

		Velocity = vel;


		Inert*=0.8f;
	}



	public Vector2 Inert {get;set;}

	public int Health {get;set;}

	public int MaxHealth {get;set;}

	

}
