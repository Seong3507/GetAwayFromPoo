using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool intouch { get; set; }
    public bool isGameOver { get; set; }
    private Touch tempTouchs;
    private Vector3 touchedPos;
    private bool touchOn;

    private void Awake()
    {
        intouch = false;
        isGameOver = false;
    }
    private void Update()
    {

        touchOn = false; if (Input.touchCount > 0)
        {
            //터치가 1개 이상이면.    
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);
                if (tempTouchs.phase == TouchPhase.Began)
                {
                    //해당 터치가 시작됐다면.            
                    touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);//get world position.
                    touchOn = true;
                    intouch = true;
                    UIManager.Instance.gameStart = true;
                    Time.timeScale = 1;
                    break;   //한 프레임(update)에는 하나만.
                }
            }
        }
        if (Input.GetButtonDown("Fire1") && intouch != true)
        {
            Time.timeScale = 1;
            intouch = true;
            UIManager.Instance.gameStart = true;
        }

        if (isGameOver == true)
            Time.timeScale = 0;



    }
}
