using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICheckUnit : MonoBehaviour
{
    UIMove uiMove;
    private void Start()
    {
        uiMove = GetComponent<UIMove>();
    }
    private void Update()
    {
        for(int i = 0; i < uiMove.posBase.Length; i++)
        {
            if(uiMove.posBase[i] != null)
            {
                float distan = Vector2.Distance(uiMove.posBase[i].GetComponent<Base>().unit.transform.position, gameObject.transform.position);
                if (distan <= 2)
                    uiMove.enemy = uiMove.posBase[i].GetComponent<Base>().unit;
                else
                    uiMove.enemy = null;
            }
        }    
    }
}
