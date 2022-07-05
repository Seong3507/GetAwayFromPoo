using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Poo : MonoBehaviour
{

    BoxCollider boxCollider;
    PlayerInput playerInput;
    PlayerMovement playerMovement;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.Die();
        }
        if (collision.gameObject.tag == "Ground")
        {

            StartCoroutine(Fade());
        }

    }


    public IEnumerator Fade()
    {
        Vector2 size = new Vector2(3f, 3f);
        spriteRenderer.DOFade(0f, 0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        transform.DOScale(size, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
