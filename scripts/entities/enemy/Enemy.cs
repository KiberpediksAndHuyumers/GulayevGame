using Godot;
using Godot.Collections;

public class Enemy : KinematicBody2D
{
    Player player;
    NavigationAgent2D navigationAgent2D;

    Sprite sprite;

    float speed = 100;

    public override void _Ready()
    {
        base._Ready();

        navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
        sprite = GetNode<Sprite>("CollisionShape2D/Sprite");

        Array players = GetTree().GetNodesInGroup("Player");
        player = (Player)players[0];
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        navigationAgent2D.SetTargetLocation(player.GlobalPosition);
        Vector2 velocity = GlobalPosition.DirectionTo(navigationAgent2D.GetNextLocation());
        if (velocity.x > 0)
        {
            sprite.FlipH = true;
        }
        else
        {
            sprite.FlipH = false;
        }

        navigationAgent2D.SetVelocity(velocity);
    }

    public void _onArea2DBodyEntered(Node body)
    {
        if (body.Name == "Player")
        {
            Player _player = (Player)body;
            _player.TakeDamage(1);
        }
    }

    public void _OnNavigationAgent2DVelocityComputed(Vector2 safeVelocity)
    {
        MoveAndSlide(safeVelocity * speed);
    }

    public void TakeDamage(int amount)
    {
        QueueFree();
    }
}
