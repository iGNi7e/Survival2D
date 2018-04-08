using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;

    private void Awake()
    {
        SetDefault();
    }

    public void SetDefault()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        Debug.Log(transform.name + " has health " + currentHealth);
    }
}
