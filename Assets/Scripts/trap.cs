using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class trap : MonoBehaviour
{
    public GameObject trap1;
    public GameObject trap2;
    public GameObject player;
    GameObject pooPrefab;
    PlayerInput playerInput;
    GameManager gameManager;
    float trapY = -4.5f;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        SpawnTrap();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        gameManager.Die();
    //    }

    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    StartCoroutine(Fade());
    //    //}
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.Die();
        }
    }

    private void Update()
    {
        SpawnTrap();
    }

    private void SpawnTrap()
    {
        float yScreenHalfSize = Camera.main.orthographicSize;
        float xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
        trap1.transform.position = new Vector2(-xScreenHalfSize, trapY);
        trap2.transform.position = new Vector2(xScreenHalfSize, trapY);
    }

    public IEnumerator Fade()
    {
        Vector2 size = new Vector2(3f, 3f);
        pooPrefab.GetComponent<SpriteRenderer>().DOFade(0f, 1f);
        pooPrefab.GetComponent<BoxCollider2D>().enabled = false;
        pooPrefab.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pooPrefab.transform.DOScale(size, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(pooPrefab);
    }
}
