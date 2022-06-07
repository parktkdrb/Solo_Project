using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public Transform ClickWhiteObject;
    public Transform ClickBlackObject;
    public Transform Check1;
    public Transform Check2;
    public Transform Check3;
    public Transform Check4;
    public Transform Check5;
    public Transform Check6;
    public Transform Check7;
    public Transform Check8;

    /*
    private GameObject WhiteFiveGaro;
    private GameObject BlackFiveGaro;
    private GameObject WhiteFiveSero;
    private GameObject BlackFiveSero;
    private GameObject WhiteFiveDagak_M45;
    private GameObject BlackFiveDagak_M45;
    private GameObject WhiteFiveDagak_45;
    private GameObject BlackFiveDagak_45;
    /*
    int W_g;
    int W_g_v = 0;
    int W_s;
    int W_s_v;
    int W_md;
    int W_md_v;
    int W_d;
    int W_d_v;
    int B_s;
    int B_s_v;
    int B_g;
    int B_g_v;
    int B_md;
    int B_md_v;
    int B_d;
    int B_d_v;
    int[] White = new int[225]; //가로 * 세로 = 225
    int[] Black = new int[225]; //가로 * 세로 = 225
    // Start is called before the first frame update
    */
    public void Start()
    {


    }


    public void OnMouseDown()
    {
        //GameObject[] WhiteFiveGaro = GameObject.FindGameObjectsWithTag("WhiteGaroLine");//흰색돌 가로줄
        //GameObject[] WhiteFiveSero = GameObject.FindGameObjectsWithTag("WhiteSeroLine");//흰색돌 세로줄
        //GameObject[] WhiteFiveDagak_M45 = GameObject.FindGameObjectsWithTag("WhiteDagak-45Line");//흰색돌 -45대각
        //GameObject[] WhiteFiveDagak_45 = GameObject.FindGameObjectsWithTag("WhiteDagak45Line");//흰색돌 45대각
        //GameObject[] BlackFiveGaro = GameObject.FindGameObjectsWithTag("BlackGaroLine");//검은돌 가로줄
        //GameObject[] BlackFiveSero = GameObject.FindGameObjectsWithTag("BlackSeroLine");//검은돌 세로줄
        //GameObject[] BlackFiveDagak_M45 = GameObject.FindGameObjectsWithTag("BlackDagak-45Line");//검은돌 -45대각
        //GameObject[] BlackFiveDagak_45 = GameObject.FindGameObjectsWithTag("BlackDagak45Line");//검은돌 45대각


        if (GM.currentTurn == "w")
        {
            Instantiate(ClickWhiteObject, transform.position, ClickWhiteObject.rotation);
            gameObject.tag = "WhiteBox";
            GM.currentTurn = "b";

            Instantiate(Check1, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check2, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check3, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check4, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check5, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check6, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check7, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check8, transform.position, ClickWhiteObject.rotation);
            Debug.Log("흰색체크 생성");

        }
        else if (GM.currentTurn == "b")
        {
            Instantiate(ClickBlackObject, transform.position, ClickBlackObject.rotation);
            gameObject.tag = "BlackBox";
            GM.currentTurn = "w";
            
            Instantiate(Check1, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check2, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check3, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check4, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check5, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check6, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check7, transform.position, ClickWhiteObject.rotation);
            Instantiate(Check8, transform.position, ClickWhiteObject.rotation);;
            Debug.Log("검은색체크 생성");
            
        }
    }


    
         
        

}


    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WhiteGaroLine" && collision.tag == "WhiteGaroLine") // 가로선 끼리 충돌했을때
        {

            if (collision.tag != "WhiteGaroLine")// 다른 붙어있지 않은 가로줄이라면
            {
                White[W_g] = W_g + 1;//새로운 배열에
                White[W_g] = {W_g_v};
            }
            else 
            {
                White[W_g] = 0;// 아니면 있던 배열에 
                W_g++;//값 1 상승???? 이러면 새로 생겼을때 계속 값이 상승하는데 이전에 배열에는 어떻게 오지?
            }

            Debug.Log(White[W_g]);

        }
        if (collision.tag == "WhiteSeroLine" && collision.tag == "WhiteSeroLine")
        {
            if (collision.tag != "WhiteSeroLine")
            {
                White[W_s] = W_s + 1;
                W_s++;
            }
            else
            {
                White[W_s] = 0;
                W_s++;
            }
            Debug.Log(White[W_s]);

        }
        if (collision.tag == "WhiteDagak-45Line" && collision.tag == "WhiteDagak-45Line")
        {
            if (collision.tag != "WhiteDagak-45Line")
            {
                White[W_md] = W_md + 1;
                W_md++;
            }
            else
            {
                White[W_md] = 0;
                W_md++;
            }
            Debug.Log(White[W_md]);
        }
        if (collision.tag == "WhiteDagak45Line" && collision.tag == "WhiteDagak45Line")
            if (collision.tag != "WhiteDagak45Line")
            {
                White[W_d] = W_d + 1;//
                W_d++;
            }
            else
            {
                White[W_d] = 0;
                W_d++;
            }
        Debug.Log(White[W_d]);

        if (collision.tag == "BlackGaroLine" && collision.tag == "BlackGaroLine")
            if (collision.tag != "BlackGaroLine")// 
            {
                White[B_g] = B_g + 1;//
                B_g++;
            }
            else
            {
                White[B_g] = 0;
                B_g++;
            }
        Debug.Log(White[B_g]);

        if (collision.tag == "BlackSeroLine" && collision.tag == "BlackSeroLine") //
        {
            if (collision.tag != "BlackSeroLine")//
            {
                White[B_s] = B_s + 1;//
                B_s++;
            }
            else
            {
                White[B_s] = 0;
                B_s++;
            }
            Debug.Log(White[B_s]);

            if (collision.tag == "BlackDagak-45Line" && collision.tag == "BlackDagak-45Linee") // 
            {
                if (collision.tag != "BlackDagak-45Line")//
                {
                    White[B_md] = B_md + 1;//
                    B_md++;
                }
                else
                {
                    White[B_md] = 0;
                    B_md++;
                }
                Debug.Log(White[B_md]);
            }
            if (collision.tag == "BlackDagak45Line" && collision.tag == "BlackDagak45Line") //
            {
                if (collision.tag != "BlackDagak45Line")//
                {
                    White[B_d] = B_d + 1;//
                    B_d++;
                }
                else
                {
                    White[B_d] = 0;
                }
                Debug.Log(White[B_d]);
            }


        }
    }*/


