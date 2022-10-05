using Godot;
using Godot.Collections;

public class Enemy : KinematicBody2D
{
    Player player;

    float speed = 100;

    public override void _Ready()
    {
        base._Ready();

        Array players = GetTree().GetNodesInGroup("Player");
        player = (Player)players[0];
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);

        Vector2 velocity = GlobalPosition.DirectionTo(player.GlobalPosition);
        MoveAndCollide(velocity * speed * delta);
    }

    public void _onArea2DBodyEntered(Node body)
    {
        if (body.Name == "Player")
        {
            player.TakeDamage(1);
        }
    }
}
