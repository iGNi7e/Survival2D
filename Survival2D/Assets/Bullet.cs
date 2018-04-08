using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [Client] //выполняется только на клиенте
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == PLAYER_TAG)
        {
            CmdShootPlayer(col.collider.name,weapon.damage);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    [Command] //выполняются только на сервере
    private void CmdShootPlayer(string _playerID, int _damage)
    {
        Debug.Log(_playerID + " has been shot");

        Player _player = GameManager.GetPlayer(_playerID);
        _player.TakeDamage(_damage);
    }
}
