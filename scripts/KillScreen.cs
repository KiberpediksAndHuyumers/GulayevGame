using Godot;
using System;

public class KillScreen : TextureRect
{
    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        Modulate = new Color(Modulate.r, Modulate.g, Modulate.b, Modulate.a + 0.001f);
    }
}
