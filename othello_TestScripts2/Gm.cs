using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm : MonoBehaviour
{
    public Transform BoxObj;

    public static string currentTurn = "w";
    public static string CM = "C";
    void Start()
    {
        for (float y = 4; y > -5; y  -= 1.2f)
        {
            for (float x = -4; x < 5; x += 1.2f)
            {
                Instantiate(BoxObj, new Vector2(x, y), BoxObj.rotation);

            }
        }
    }

    void Update()
    {
        
    }
}
