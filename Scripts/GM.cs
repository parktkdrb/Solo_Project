using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public Transform BoxObj;
    float size = 15;

    public static string currentTurn = "w";
    public static string Click = "c";
    void Start()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                Instantiate(BoxObj, new Vector2(i, j), BoxObj.rotation);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
            
    }
    
}
