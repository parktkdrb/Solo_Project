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
        this.transform.Translate(0, -Speed, 0);// �����̱�

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�� ���ھ� : ");
            Debug.Log(WhiteScore);// WhiteScore�� �ܼ�â�� ����
            Debug.Log("������ ���ھ� : ");
            Debug.Log(BlackScore);//
            Debug.Log("Turn End");// a�� �ܼ�â�� ����
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�� ------------------------------------------------------------------------- 

        //�� ------------------------------------------------------------------------- 

        if (other.gameObject.tag == "WhiteBox")// ���� WhiteBox �±׸� ���� ���� ������(�ڽ�obj��?)
        {
            WhiteScore++;//WhiteScore�� 1+

            if (WhiteScore == 6)// WhiteScore�� 5�� �Ǹ� �� �¸�
            {
                SceneManager.LoadScene("WhiteScene");
                Debug.Log("�� �¸�!");
            }
        }
        else if (other.gameObject.tag == "BlackBox" || other.gameObject.tag == "Box")// ���� BlackBox �±׳� �׳� Box �±׸� ������ 
        {
            WhiteScore = 1;//WhiteScore�� 1�� �ʱ�ȭ
        }

        //������ ---------------------------------------------------------------------- 
        if (other.gameObject.tag == "BlackBox")
        {
            BlackScore++;

            if (BlackScore == 6)
            {
                SceneManager.LoadScene("BlackScene");
                Debug.Log("������ �¸�!");
            }
        }
        else if (other.gameObject.tag == "WhiteBox" || other.gameObject.tag == "Box")
        {
            BlackScore = 1;
        }

    }
}
