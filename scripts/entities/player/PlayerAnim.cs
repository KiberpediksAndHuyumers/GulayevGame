using Godot;
using System;

public class PlayerAnim : AnimatedSprite
{
    public override void _Ready()
    {
        base._Ready();

        Playing = true;
    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        float horizontalDirection = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        float verticalDirection = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

        if (horizontalDirection != 0 || verticalDirection != 0)
        {
            Animation = "run";
            SpeedScale = Mathf.Abs(horizontalDirection) + Mathf.Abs(verticalDirection);
        }
        else
        {
            Animation = "idle";
            SpeedScale = 1;
        }
    }
}
