using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Contoll : MonoBehaviour
{
    public Transform ClickWhiteObject;
    public Transform ClickBlackObject;
    public Transform CheckObject;
    

    private void OnMouseDown()
    {
        if (Gm.currentTurn == "w")
        {
            Instantiate(ClickWhiteObject, transform.position, ClickWhiteObject.rotation);
            // Gm.currentTurn = "b";
            StartCoroutine(waitstonechangeB());
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(CheckObject, transform.position, CheckObject.rotation);
        }
        else if (Gm.currentTurn == "b")
        {
            Instantiate(ClickBlackObject, transform.position, ClickBlackObject.rotation);
            //Gm.currentTurn = "w";
            StartCoroutine(waitstonechangeW());
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(CheckObject, transform.position, CheckObject.rotation);
        }
    }

    IEnumerator waitstonechangeW()
    {
        yield return new WaitForSeconds(1);
        Gm.currentTurn = "w";
        Gm.CM = "n";

    }
    IEnumerator waitstonechangeB()
    {
        yield return new WaitForSeconds(1);
        Gm.currentTurn = "b";

    }
}
