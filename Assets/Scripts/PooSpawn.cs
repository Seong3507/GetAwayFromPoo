using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooSpawn : MonoBehaviour
{

    public enum diff
    {
        Easy = 10,
        EasyNormal = 20,
        Normal = 30,
        NormalHard = 40,
        Hard = 50
    }

    public enum screen
    {
        Portrait = 0,
        Landscape = 1,
    }

    BoxCollider box;
    public GameObject pooPrefab;
    public List<GameObject> pooList = new List<GameObject>();
    public diff different = diff.Easy;
    public screen screenSize = screen.Portrait;
    GameManager gameManager;
    PlayerMovement playerMovement;

    public float widthSize { get; private set; }
    public float randValue { get; private set; }
    Vector2 spawnPos;
    float yScreenHalfSize;
    float xScreenHalfSize;


    private void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;


        box = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        widthSize = box.bounds.size.x;
        StartCoroutine(BoxSpawn());
    }

    public IEnumerator BoxSpawn()
    {
        while (true)
        {
            // 가로가 있는 버전
            //if (screenSize == screen.Portrait)
            //{
            //    switch (different)
            //    {
            //        case diff.Easy:
            //            Spawn(3f);
            //            yield return new WaitForSeconds(2f);
            //            break;
            //        case diff.EasyNormal:
            //            Spawn(4f);
            //            yield return new WaitForSeconds(1f);
            //            break;
            //        case diff.Normal:
            //            Spawn(5f);
            //            yield return new WaitForSeconds(0.5f);
            //            break;
            //        case diff.NormalHard:
            //            Spawn(6f);
            //            yield return new WaitForSeconds(0.3f);
            //            break;
            //        case diff.Hard:
            //            Spawn(7f);
            //            yield return new WaitForSeconds(0.1f);
            //            break;
            //    }
            //}
            //else
            //{
            //    switch (different)
            //    {
            //        case diff.Easy:
            //            StartCoroutine(SpawnLand(3f, 5));
            //            yield return new WaitForSeconds(2f);
            //            break;
            //        case diff.EasyNormal:
            //            StartCoroutine(SpawnLand(4f, 4));
            //            yield return new WaitForSeconds(1f);
            //            break;
            //        case diff.Normal:
            //            StartCoroutine(SpawnLand(5f, 3));
            //            yield return new WaitForSeconds(0.5f);
            //            break;
            //        case diff.NormalHard:
            //            StartCoroutine(SpawnLand(6f, 3));
            //            yield return new WaitForSeconds(0.3f);
            //            break;
            //        case diff.Hard:
            //            StartCoroutine(SpawnLand(7f, 3));
            //            yield return new WaitForSeconds(0.1f);
            //            break;
            //    }
            //}

            switch (different)
            {
                case diff.Easy:
                    Spawn(3f);
                    yield return new WaitForSeconds(2f);
                    break;
                case diff.EasyNormal:
                    Spawn(4f);
                    yield return new WaitForSeconds(1f);
                    break;
                case diff.Normal:
                    Spawn(5f);
                    yield return new WaitForSeconds(0.5f);
                    break;
                case diff.NormalHard:
                    Spawn(6f);
                    yield return new WaitForSeconds(0.3f);
                    break;
                case diff.Hard:
                    Spawn(7f);
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
        }
    }
    private void Update()
    {
        // Debug.Log(screenSize);
        // Debug.Log(Screen.orientation);

        if (Screen.orientation == ScreenOrientation.Portrait ||
            Screen.orientation == ScreenOrientation.PortraitUpsideDown)     // 세로방향
        {
            screenSize = screen.Portrait;
            // playerMovement.gameObject.transform.position = new Vector2(playerMovement.gameObject.transform.position.x / xScreenHalfSize, playerMovement.gameObject.transform.position.y);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight)         // 가로방향
        {
            screenSize = screen.Landscape;
           // playerMovement.gameObject.transform.position = new Vector2(playerMovement.gameObject.transform.position.x / xScreenHalfSize, playerMovement.gameObject.transform.position.y);
        }
    }
    private void Spawn(float speed)
    {
        randValue = Random.Range(-xScreenHalfSize, xScreenHalfSize);
        spawnPos = new Vector2(randValue, transform.position.y);
        GameObject poo = Instantiate(pooPrefab, spawnPos, Quaternion.identity);
        playerMovement.moveSpeed = speed;
        pooList.Add(poo);
    }
    //private IEnumerator SpawnLand(float speed, int dif)
    //{
    //    float rand = Random.Range(0f, 0.3f);
    //    for (int i = 0; i < dif; i++)
    //    {
    //        GameObject poo = Instantiate(pooPrefab, spawnPos, Quaternion.identity);
    //        playerMovement.moveSpeed = speed;
    //        pooList.Add(poo);
    //        yield return new WaitForSecondsRealtime(rand);
    //    }
    //}
}



// Transform.SetAsFirstSibling;