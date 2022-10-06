using Godot;
using System;

public class NetworkSetup : Control
{
    TextEdit serverIP;
    Label deviceIP;

    Control multiplayerUI;

    public override void _Ready()
    {
        serverIP = GetNode<TextEdit>("Multiplayer/ServerIP");
        deviceIP = GetNode<Label>("CanvasLayer/DeviceIP");

        multiplayerUI = GetNode<Control>("Multiplayer");

        deviceIP.Text = Network.network.ipAddress;
    }

    public void _OnCreateServerPressed()
    {
        multiplayerUI.Hide();
        Network.network.CreateServer();
    }

    public void _OnJoinServerPressed()
    {
        if (serverIP.Text != "")
        {
            multiplayerUI.Hide();
            Network.network.ipAddress = serverIP.Text;
            Network.network.JoinServer();
        }
    }
}
