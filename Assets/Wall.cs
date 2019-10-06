using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float defaultHp = 0;
    public int hp = 2;
    public Sprite[] BrokenWallSprite; 
    private void Start()
    {
        defaultHp = hp;
    }
    public void DamageWall(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        } else if(defaultHp / 2 >= hp)
        {
            GetComponent<SpriteRenderer>().sprite = BrokenWallSprite[Random.Range(0,BrokenWallSprite.Length)];
        }
    }
}
