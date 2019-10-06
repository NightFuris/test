using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Unit unit;
    public GameObject prefabsBullet;
    public Transform pointGun;
    public AudioSource audioSourceGun;
    void Start()
    {
        unit = GetComponent<Unit>();
    }
    bool isAct = true;
    public float seconds = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isAct)
        {
            audioSourceGun.Play();
            GameObject bullet = Instantiate(prefabsBullet);
            bullet.GetComponent<Bullet>().unit = unit;
            bullet.transform.position = pointGun.position;
            bullet.transform.rotation = pointGun.rotation;
            isAct = false;
        }
        if (!isAct)
        {
            seconds += Time.deltaTime;
            if(seconds >= unit.speedRechargeGun)
            {
                isAct = true;
                seconds = 0;
            }
        }
    }
}
