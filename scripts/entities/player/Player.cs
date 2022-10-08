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

    int health = 10;

    AnimatedSprite animatedSprite;
    AnimationPlayer attackAnim;

    public override void _Ready()
    {
        base._Ready();

        animatedSprite = GetNode<AnimatedSprite>("CollisionShape2D/AnimatedSprite");
        attackAnim = GetNode<AnimationPlayer>("CollisionShape2D/AnimatedSprite/Area2D/AnimationPlayer");
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
            animatedSprite.Scale = new Vector2(-Scale.x, Scale.y);
        }
        else if (velocity.x > 0)
        {
            animatedSprite.Scale = new Vector2(Scale.x, Scale.y);
        }

        velocity = MoveAndSlide(velocity, upDirection);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsAction("player_attack"))
        {
            attackAnim.Play("SlashAttack");
        }
    }

    public void TakeDamage(int amount)
    {
        HUD.instance.TakeDamage(amount);
        health -= amount;
        if (health <= 0)
        {
            GetTree().ChangeScene("res://scenes/KillScreen.tscn");
        }
    }

    public void _OnArea2DBodyEntered(Node body)
    {
        if (body.IsInGroup("Enemy"))
        {
            Enemy _enemy = (Enemy)body;
            _enemy.TakeDamage(1);
        }
    }
}
