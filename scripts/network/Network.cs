using Godot;
using System;

public class Network : Node
{
    const int defaultPort = 28960;
    const int maxClients = 2;

    NetworkedMultiplayerENet server;
    NetworkedMultiplayerENet client;

    public string ipAddress;

    public static Network network;

    public override void _Ready()
    {
        base._Ready();

        network = this;

        if (OS.GetName() == "Android")
        {
            ipAddress = IP.GetLocalAddresses()[0].ToString();
        }
        else
        {
            ipAddress = IP.GetLocalAddresses()[3].ToString();
        }

        foreach (string ip in IP.GetLocalAddresses())
        {
            if (ip.BeginsWith("192.168."))
            {
                ipAddress = ip;
            }
        }

        GetTree().Connect("connected_to_server", this, "ConnectedToServer");
        GetTree().Connect("server_disconnected", this, "ServerDisconnected");

        //new Network().CreateServer();
    }

    public void CreateServer()
    {
        server = new NetworkedMultiplayerENet();
        server.CreateServer(defaultPort, maxClients);
        GetTree().NetworkPeer = server;
    }

    public void JoinServer()
    {
        client = new NetworkedMultiplayerENet();
        client.CreateClient(ipAddress, defaultPort);
        GetTree().NetworkPeer = client;
    }

    void ConnectedToServer()
    {
        GD.Print("Successfully connected to the server");
    }

    void ServerDisconnected()
    {
        GD.Print("Disconnected from the server");
    }
}
