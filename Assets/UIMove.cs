using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    public Transform[] posBase;
    int idMove = 0;
    public GameObject enemy;
    Transform posBaseAttacke;
    Rigidbody2D rb;
    Unit unit;
    AudioSource moveAudio;
    public GameObject spritePlayer;
    Transform pointGun;
    private void Start()
    {
        pointGun = GetComponent<UIGun>().pointGun;
        moveAudio = GetComponent<AudioSource>();
        unit = GetComponent<Unit>();
        rb = GetComponent<Rigidbody2D>();
        posBase = unit.RespawnBase.GetComponent<Base>().posBase;
        AttackeBase(); 
}
    void AttackeBase()
    {
        float dist = 100f;
        for(int i = 0; i < posBase.Length; i++)
        {
            if(posBase[i] != null)
            {
                if(dist >= Vector2.Distance(transform.position, posBase[i].position))
                {
                    dist = Vector2.Distance(transform.position, posBase[i].position);
                    posBaseAttacke = posBase[i];
                }
            }
        }
    }
    float moveRotationX = 0;
    Vector2 vector;
    public bool isStop = false;
    void Move()
    {
        Transform posObj;
        if (enemy != null)
            posObj = enemy.transform;
        else if (posBaseAttacke == null)
        {
            AttackeBase();
            posObj = posBaseAttacke;
        }
        else
        {
            posObj = posBaseAttacke;
        }

        if (posObj == null) return;
        vector = Vector2.zero;
        float distansY = Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, posObj.transform.position.y));
        if (distansY <= 0.1f)
        {
            if (posObj.transform.position.x > transform.position.x)
            {
                vector.x = unit.speedMove;
                moveRotationX = -90f;
            }
            else
            {
                vector.x = -unit.speedMove;
                moveRotationX = 90f;
            }
        }
        else if (posObj.transform.position.y > transform.position.y)
        {
            vector.y = unit.speedMove;
            moveRotationX = 0f;
        }
        else
        {
            vector.y = -unit.speedMove;
            moveRotationX = 180f;
        }
        rb.velocity = vector;
        spritePlayer.transform.rotation = Quaternion.Euler(0, 0, moveRotationX);
    }
    void Update()
    {
        Ray2D ray = new Ray2D(new Vector2(pointGun.position.x, pointGun.position.y), -pointGun.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);
        if (hit.collider != null && hit.collider.name != gameObject.name)
        {
            if (hit.collider.GetComponent<Wall>() != null)
                isStop = true;
            else if (hit.collider.GetComponent<Unit>() != null)
                isStop = true;
            else if (hit.collider.GetComponent<Base>() != null && hit.collider.gameObject != unit.RespawnBase)
            {
                if (hit.collider.GetComponent<Base>().unit != gameObject)
                    isStop = true;
            }
            else
            {
                isStop = false;
            }
        }
        else
        {
            isStop = false;
        }
        if (!isStop)
            Move();
    }
}
