using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    //[Client]
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == PLAYER_TAG)
        {
            CmdShootPlayer(col.collider.name);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    //[Server]
    private void CmdShootPlayer(string _ID)    {
        Debug.Log(_ID + " has been shot");
    }
}
