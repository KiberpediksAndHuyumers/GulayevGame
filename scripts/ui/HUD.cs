using Godot;

public class HUD : CanvasLayer
{
    public static HUD instance;

    TextureProgress progressBar;
    Control mobileControls;

    public override void _Ready()
    {
        instance = this;

        mobileControls = GetNode<Control>("MobileControls");
        if (OS.GetName() != "Android")
        {
            RemoveChild(mobileControls);
        }

        progressBar = GetNode<TextureProgress>("ProgressBar");
    }

    public void TakeDamage(int amount)
    {
        progressBar.Value -= amount;
    }

    public void _OnTextureButtonPressed()
    {
        InputEventAction ev = new InputEventAction();
        ev.Action = "player_attack";
        ev.Pressed = true;

        Input.ParseInputEvent(ev);
    }
}
