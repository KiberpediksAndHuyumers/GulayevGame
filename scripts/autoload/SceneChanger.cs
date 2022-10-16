using Godot;
using System;

public class SceneChanger : Node
{
    public static SceneChanger Instance { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

    private void ChangeSceneTo(string scenePath)
    {
        ResourceInteractiveLoader loader = ResourceLoader.LoadInteractive(scenePath);

        while (true)
        {
            Error err = loader.Poll();
            if (err == Error.FileEof)
            {
                Resource resource = loader.GetResource();
                GetTree().Root.CallDeferred("add_child", resource.GetInstanceId());
            }
        }
    }
}
