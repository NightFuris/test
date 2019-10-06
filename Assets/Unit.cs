using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speedMove = 3f;
    public float speedRechargeGun = 1f;
    public float speedFlightBullet = 2f;
    public float timeLifeBullet = 1f; 
    public int damageBullet = 1;
    public int hp = 10;
    public GameObject RespawnBase;
    public bool isGod = false;
    void Update()
    {
        if (RespawnBase == null)
            Destroy(gameObject);
    }
    public void DamageUnit(int damage)
    {
        if (!isGod)
        {
            hp -= damage;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
