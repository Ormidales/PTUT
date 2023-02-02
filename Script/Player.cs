using Godot;
using System;

public partial class Player : Entity
{
	[Export]
	public float Speed {get;set;} = 150.0f;


	[Export]
	public float JumpVelocity {get;set;} = -200.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{

		base._PhysicsProcess(delta);

		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("game_left", "game_right", "game_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.x = direction.x * Speed;
		}
		else
		{
			velocity.x = Mathf.MoveToward(Velocity.x, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
