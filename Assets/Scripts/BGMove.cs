using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{

    public float speed;
    public Transform[] backgrounds;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        if (xScreenHalfSize * 2 > yScreenHalfSize)
        {
            leftPosX = -(xScreenHalfSize * 1.5f);
            rightPosX = xScreenHalfSize * 3.5f;
        }
        else
        {
            leftPosX = -(xScreenHalfSize * 2f);
            rightPosX = xScreenHalfSize * backgrounds.Length;
        }

        

    }

    private void Update()
    {
        if (xScreenHalfSize * 2 > yScreenHalfSize)
        {
            leftPosX = -(xScreenHalfSize * 1.5f);
            rightPosX = xScreenHalfSize * 3.5f;
        }
        else
        {
            leftPosX = -(xScreenHalfSize * 2f);
            rightPosX = xScreenHalfSize * backgrounds.Length;
        }
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].position.x < leftPosX)
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector2(nextPos.x + rightPosX, nextPos.y);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
