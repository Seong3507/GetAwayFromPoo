using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using com.adjust.sdk;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    public TextMeshProUGUI mainMenu;
    public GameObject gameOverRes;
    public GameObject gameOverNo;
    public PlayerInput playerInput;
    public PooSpawn pooSpawn;
    public PlayerMovement playerMovement;
    public GameObject removeAd;
    public bool AdRemove;

    GameObject player;
    GoogleAd googleAd;

    float time;


    public bool gameStart { get; set; }


    int count;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(UIManager)) as UIManager;
            return instance;
        }

    }

    private void Awake()
    {
        StartCoroutine(HideAd(AdRemove));
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        player = GameObject.Find("Player");



        gameStart = false;
        gameOverRes.SetActive(false);
        gameOverNo.SetActive(false);
        Time.timeScale = 0;
        count = 0;
    }


    private void Start()
    {
        googleAd = FindObjectOfType<GoogleAd>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("씬 불러왔을 때!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + AdRemove);
        StartCoroutine(HideAd(AdRemove, 0.01f));
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (instance.gameStart == true)
        {
            mainMenu.enabled = false;
        }

        if (playerInput.isGameOver == true && count == 0)
        {

            StartCoroutine(One());
            ++count;
        }
        else if (playerInput.isGameOver == true && count == 2)
        {
            StartCoroutine(One());
            ++count;
        }


    }


    public void adResurrection()
    {
        AdjustEvent rewarededAdEvent = new AdjustEvent("n02rni");
        Adjust.trackEvent(rewarededAdEvent);
        if (AdRemove != true)
        {
            googleAd.ShowAds();
        }
        else
        {
            Resurrection();
        }
    }

    public void Resurrection()
    {
        Vector2 size = new Vector2(3f, 3f);
        playerInput.isGameOver = false;
        instance.gameStart = false;
        gameOverRes.SetActive(false);
        gameOverNo.SetActive(false);
        player.transform.position = new Vector2(0f, playerMovement.startPosValue);
        player.transform.DOScale(size, 1f).SetUpdate(true);

        mainMenu.enabled = true;
        for (int i = pooSpawn.pooList.Count - 1; i >= 0; i--)
        {
            Destroy(pooSpawn.pooList[i]);
        }
        pooSpawn.pooList.Clear();

        playerMovement.MoveStart();
        count++;

        Time.timeScale = 0;
        
    }

    public void No()
    {
        AdjustEvent rewarededAdEvent = new AdjustEvent("gndkht");
        Adjust.trackEvent(rewarededAdEvent);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    //public void AdButton()
    //{
    //    if (AdRemove == true)
    //    {
    //        btnRemove.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        btnRemove.gameObject.SetActive(true);
    //    }
    //}

    public IEnumerator HideAd(bool remove, float sec = 0.1f)
    {

        yield return new WaitForSecondsRealtime(sec);
        if (remove == true)
        {
            AdRemove = true;
            removeAd.SetActive(false);
        }
        else
        {
            removeAd.SetActive(true);
        }

    }

    public IEnumerator One()
    {
        yield return new WaitForSecondsRealtime(2f);
        if (count == 1)
        {
            gameOverRes.transform.localScale = new Vector2(0f, 0f);
            gameOverNo.transform.localScale = new Vector2(0f, 0f);
            gameOverRes.transform.DOScale(1.2f, 1f).SetUpdate(true);
            gameOverNo.transform.DOScale(1.2f, 1f).SetUpdate(true);
            gameOverRes.SetActive(true);
            gameOverNo.SetActive(true);
        }
        else
        {
            gameOverNo.transform.localScale = new Vector2(0f, 0f);
            gameOverNo.transform.DOScale(1.2f, 1f).SetUpdate(true);
            gameOverRes.SetActive(false);
            gameOverNo.SetActive(true);
        }

    }



}
