using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);


    }


    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "E")
        {
            Gm.CM = "r";
            Destroy(gameObject);
        }

        if(other.tag == Gm.currentTurn)
        {
            Gm.CM = "y";
            Destroy(gameObject);
        }
        if (other.tag != Gm.currentTurn)
        {
            other.tag = gameObject.tag;
        }
    }
}
