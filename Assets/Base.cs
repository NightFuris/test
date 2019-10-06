using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    float defaultHp = 0;
    public float timeGodUnit = 2f;
    float seconds = 0;
    public int hp = 2;
    public GameObject unit;
    public Transform pointSpawn;
    public GameObject prefabsTank;
    public Transform[] posBase = new Transform[3];
    private void Start()
    {
        defaultHp = hp;
        unit = Instantiate(prefabsTank);
        unit.transform.position = pointSpawn.position;
        unit.GetComponent<Unit>().RespawnBase = gameObject;
    }
    private void Update()
    {
        if(unit == null)
        {
            unit = Instantiate(prefabsTank);
            unit.transform.position = pointSpawn.position;
            unit.GetComponent<Unit>().RespawnBase = gameObject;
            unit.GetComponent<Unit>().isGod = true;
        }
        else if (unit.GetComponent<Unit>().isGod)
        {
            seconds += Time.deltaTime;
            if(seconds >= timeGodUnit)
            {
                seconds = 0;
                unit.GetComponent<Unit>().isGod = false;
            }
        }
    }
    public void DamageBase(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
