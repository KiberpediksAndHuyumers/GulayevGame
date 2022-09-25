using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export] Vector2 upDirection = Vector2.Up;

	[Export] float speed = 600;

	[Export] float jumpStrength = 1500;
	[Export] int maxJumps = 2;
	[Export] float doubleJumpStrength = 1200;
	[Export] float gravity = 4500;

	int jumpsMade;
	Vector2 velocity = Vector2.Zero;

	Sprite sprite;

	public override void _Ready()
	{
		base._Ready();

		sprite = GetNode<Sprite>("CollisionShape2D/Sprite");
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);

		float horizontalDirection = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		float verticalDirection = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

		velocity.x = horizontalDirection * speed;
		velocity.y = verticalDirection * speed / 1.5f;

		if (velocity.x < 0)
		{
			sprite.FlipH = true;
		}
		else if (velocity.x > 0)
		{
			sprite.FlipH = false;
		}

		velocity = MoveAndSlide(velocity, upDirection);
	}
}
