using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
  [SerializeField] private TMP_Text displayNameText = null;
  [SerializeField] private Renderer displayColorRenderer = null;

  [SyncVar(hook="HandleDisplayNameUpdate")]
  [SerializeField]
  private string displayName ="Missing Name";
  
  [SyncVar(hook="HandleDisplayColorUpdate")]
  [SerializeField]
  private Color playerColor = Color.black;

  #region Server
  [Server]
  public void SetDisplayName(string newDisplayName){
      displayName = newDisplayName;
  }

  [Server]
  public void SetPlayerColor(Color newPlayerColor){
      playerColor = newPlayerColor;
  }

  [Command]
  private void CmdSetDisplayName(string newDisplayName){
    RpcLogNewName(newDisplayName);
    SetDisplayName(newDisplayName);
  }

  
  #endregion

  #region Client
  private void HandleDisplayColorUpdate(Color oldColor, Color newColor){
    displayColorRenderer.material.SetColor("_BaseColor", newColor);
  }

  private void HandleDisplayNameUpdate(string oldDisplayName, string newDisplayName){
    displayNameText.text = newDisplayName;
  }

  [ContextMenu("Set My Name")]
  private void SetMyName(){
    CmdSetDisplayName("My New Name");
  }

 [ClientRpc]
  private void RpcLogNewName(string newDisplayName){
   Debug.Log(newDisplayName);
  }
}


#endregion