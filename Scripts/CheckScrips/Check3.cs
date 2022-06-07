using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check3 : MonoBehaviour
{
    public float Speed = 10;
    int WhiteScore = 1;
    int BlackScore = 1;
    public void Update()
    {
        this.transform.Translate(0, -Speed, 0);// 움직이기

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("흰돌 스코어 : ");
            Debug.Log(WhiteScore);// WhiteScore를 콘솔창에 띄우기
            Debug.Log("검은돌 스코어 : ");
            Debug.Log(BlackScore);//
            Debug.Log("Turn End");// a를 콘솔창에 띄우고
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //흰돌 ------------------------------------------------------------------------- 

        //흰돌 ------------------------------------------------------------------------- 

        if (other.gameObject.tag == "WhiteBox")// 만약 WhiteBox 태그를 가진 놈을 만나면(박스obj랑?)
        {
            WhiteScore++;//WhiteScore에 1+

            if (WhiteScore == 6)// WhiteScore가 5가 되면 흰돌 승리
            {
                SceneManager.LoadScene("WhiteScene");
                Debug.Log("흰돌 승리!");
            }
        }
        else if (other.gameObject.tag == "BlackBox" || other.gameObject.tag == "Box")// 만약 BlackBox 태그나 그냥 Box 태그를 만나면 
        {
            WhiteScore = 1;//WhiteScore에 1로 초기화
        }

        //검은돌 ---------------------------------------------------------------------- 
        if (other.gameObject.tag == "BlackBox")
        {
            BlackScore++;

            if (BlackScore == 6)
            {
                SceneManager.LoadScene("BlackScene");
                Debug.Log("검은돌 승리!");
            }
        }
        else if (other.gameObject.tag == "WhiteBox" || other.gameObject.tag == "Box")
        {
            BlackScore = 1;
        }

    }
}
