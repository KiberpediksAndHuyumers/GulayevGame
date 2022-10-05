using Godot;
using Godot.Collections;

public class SpawnEnemies : Node
{
    Vector2[] screenEdges;
    RandomNumberGenerator random = new RandomNumberGenerator();
    [Export] PackedScene packedEnemy;

    public override void _Ready()
    {
        base._Ready();

        screenEdges = new Vector2[]
        {
            Vector2.Zero,
            new Vector2(GetViewport().Size.x, 0),
            new Vector2(0, GetViewport().Size.y),
            new Vector2(GetViewport().Size)
        };
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
    }

    public void _OnTimerTimeout()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        random.Randomize();
        KinematicBody2D enemy = packedEnemy.Instance<KinematicBody2D>();
        enemy.Position = screenEdges[random.RandiRange(0, screenEdges.Length - 1)];
        GetTree().Root.AddChild(enemy);
    }
}
