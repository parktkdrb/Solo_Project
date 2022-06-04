using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneContoll : MonoBehaviour
{
    public string MyColor;
    // Start is called before the first frame update
    void Start()
    {
        MyColor = gameObject.tag;
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "CM")
        {
            if((Gm.CM == "y") && (MyColor == "b"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                gameObject.tag = "w";
            }

            if ((Gm.CM == "y") && (MyColor == "w"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                gameObject.tag = "b";
            }
            if ((Gm.CM == "r") && (MyColor == "b"))
            {
                gameObject.tag = "b";
            }
            if ((Gm.CM == "r") && (MyColor == "w"))
            {
                gameObject.tag = "w";
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
