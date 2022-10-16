using Godot;
using System;

public class LoadingScreen : Control
{
    [Export] string scenePath;
    [Export] ProgressBar progressBar;
    

    public override void _Ready()
    {
        progressBar = GetNode<ProgressBar>("ProgressBar");

        ResourceLoader.LoadInteractive
    }
}
