using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Unit unit;
    Rigidbody2D rb;
    AudioSource moveAudio;
    public GameObject spritePlayer;
    void Start()
    {
        moveAudio = GetComponent<AudioSource>();
        unit = GetComponent<Unit>();
        rb = GetComponent<Rigidbody2D>();
    }

    float moveRotationX = 0;
    Vector2 vector;
    private void FixedUpdate()
    {
        vector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveAudio.Play();
            vector.y = unit.speedMove;
            moveRotationX = 0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveAudio.Play();
            vector.y = -unit.speedMove;
            moveRotationX = 180f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveAudio.Play();
            vector.x = -unit.speedMove;
            moveRotationX = 90f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveAudio.Play();
            vector.x = unit.speedMove;
            moveRotationX = -90f;
        }
        rb.velocity = vector;
        spritePlayer.transform.rotation = Quaternion.Euler(0, 0, moveRotationX);
    }
}
