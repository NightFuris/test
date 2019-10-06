using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Unit unit;
    public float timeLifeBullet = 1f; 
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeLifeBullet = unit.timeLifeBullet;
    }

    private void Update()
    {
        transform.Translate(new Vector2(-unit.speedFlightBullet * Time.deltaTime, 0));
        timeLifeBullet -= Time.deltaTime;
        if(timeLifeBullet <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Wall>() != null)
        {
            collision.collider.GetComponent<Wall>().DamageWall(unit.damageBullet);
            Destroy(gameObject);
        } else if(collision.collider.GetComponent<Base>() != null)
        {
            Base obj = collision.collider.GetComponent<Base>();
            if (obj.unit != unit.gameObject)
                obj.DamageBase(unit.damageBullet);
            Destroy(gameObject);
        } else if(collision.collider.GetComponent<Unit>() != null)
        {
            Unit obj = collision.collider.GetComponent<Unit>();
            if (unit != obj)
            {
                obj.DamageUnit(unit.damageBullet);
                Destroy(gameObject);
            }
        }

    }
}
