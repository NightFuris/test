using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGun : MonoBehaviour
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
    void Vustrel()
    {
        audioSourceGun.Play();
        GameObject bullet = Instantiate(prefabsBullet);
        bullet.GetComponent<Bullet>().unit = unit;
        bullet.transform.position = pointGun.position;
        bullet.transform.rotation = pointGun.rotation;
        isAct = false;
    }
    void Update()
    {
        Ray2D ray = new Ray2D(new Vector2(pointGun.position.x, pointGun.position.y), -pointGun.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5f);
        if (hit.collider != null && isAct && hit.collider.name != gameObject.name)
            if (hit.collider.GetComponent<Unit>() != null)
            {
                Vustrel();
            }
            else if (hit.collider.GetComponent<Wall>() != null)
            {
                Vustrel();
            }
            else if (hit.collider.GetComponent<Base>() != null && hit.collider.gameObject != unit.RespawnBase)
            {
                Vustrel();
            }
        if (!isAct)
        {
            seconds += Time.deltaTime;
            if (seconds >= unit.speedRechargeGun)
            {
                isAct = true;
                seconds = 0;
            }
        }
    }
}
