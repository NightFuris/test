using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mech : MonoBehaviour
{
    public Transform[] posBase = new Transform[4];
    int numBase = 4;

    void Update()
    {
        if (numBase == 1)
            SceneManager.LoadScene(1);
        else numBase = 4;
        for (int i = 0; i < posBase.Length; i++)
        {
            if (posBase[i] == null)
                numBase--;
        }
    }
}
