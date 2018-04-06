using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{

    public PlayerWeapon playerWeapon;

    public GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    void Start()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform item in child)
            {
                if (item.name == "BulletSpawn")
                {
                    bulletSpawn = item;
                }
            }
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CmdShot();
        }
    }

    //1) [ClientRpc] функции выполняются на всех клиентах, но их можно запускать ТОЛЬКО с сервера.
    //2) [Command] функции выполняются только на сервере, но ВЫЗВАТЬ ее можно на клиенте и только через объект который помечен как isLocalPlayer.

    [Command]
    void CmdShot()
    {
        Debug.Log("SHOOT");
        if (bulletSpawn == null)
        {
            Debug.Log("bulletSpawn == null");
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.transform.position,Quaternion.identity);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.AddForce(bulletSpawn.transform.up * 10f,ForceMode2D.Impulse);
        NetworkServer.Spawn(bullet);
    }
}
