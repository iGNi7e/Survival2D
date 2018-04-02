using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public PlayerWeapon playerWeapon;

    public GameObject bulletPrefab;

    GameObject bulletSpawn;
    GameObject weaponSpawn;
    
	void Start () {
        if (isLocalPlayer)
            {
                bulletSpawn = GameObject.Find("BulletSpawn");
                weaponSpawn = GameObject.Find("Pistol");
        }

    }
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.transform.position,Quaternion.identity);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();   
        bulletrb.AddForce(bulletSpawn.transform.up,ForceMode2D.Impulse);
    }
}
