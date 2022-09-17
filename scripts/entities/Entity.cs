using Godot;
using System;

public class Entity : KinematicBody2D
{
    [Export] Vector2 upDirection = Vector2.Up;

    [Export] float speed = 600;

    [Export] float jumpStrength = 1500;
    [Export] int maxJumps = 2;
    [Export] float doubleJumpStrength = 1200;
    [Export] float gravity = 4500;

    int jumpsMade;
    Vector2 velocity = Vector2.Zero;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        float horizontalDirection = (Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"));

        velocity.x = horizontalDirection * speed;
        velocity.y += gravity * delta;

        velocity = MoveAndSlide(velocity, upDirection);
    }
}
