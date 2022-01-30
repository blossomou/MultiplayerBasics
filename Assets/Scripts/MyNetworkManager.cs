using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("I connected to a server!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        
        Debug.Log("We have a new player!");
        Debug.Log($"Active Players Online: {this.numPlayers}");
    }
}
