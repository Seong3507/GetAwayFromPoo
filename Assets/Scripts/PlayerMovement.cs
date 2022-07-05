using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public enum dir
    {
        NONE = 0,
        LEFT = 1,
        RIGHT = 2
    }

    public dir direction = dir.RIGHT;

    private PlayerInput playerInput;

    public float startPosValue { get; set; }
    public Vector2 startPos;
    public float moveSpeed = 5f;
    public bool wallTouch = false;




    private void Awake()
    {
        startPosValue = -4.5f;
        startPos = new Vector2(0f, startPosValue);
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        transform.position = startPos;

        MoveStart();
    }

    public void MoveStart()
    {
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        while (!playerInput.isGameOver)
        {

            if (playerInput.intouch)
            {
                switch (direction)
                {
                    case dir.NONE:
                        moveSpeed = 0f;
                        break;
                    case dir.LEFT:
                        direction = dir.RIGHT;
                        playerInput.intouch = false;
                        break;
                    case dir.RIGHT:
                        direction = dir.LEFT;
                        playerInput.intouch = false;
                        break;
                }
            }
            switch (direction)
            {
                case dir.NONE:
                    moveSpeed = 0f;
                    break;
                case dir.LEFT:
                    spriteRenderer.flipX = false;
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    yield return new WaitForSeconds(0.001f);
                    break;
                case dir.RIGHT:
                    spriteRenderer.flipX = true;
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * -1);
                    yield return new WaitForSeconds(0.001f);
                    break;
            }
        }

    }


}
