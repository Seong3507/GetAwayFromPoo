using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;
using TMPro;
using com.adjust.sdk;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    PooSpawn pooSpawn;
    public float time { get; set; }
    static float bestTime { get; set; }

    public FileStream test;
    public Image sky;
    public List<Image> cloud = new List<Image>();
    public List<Image> mountain = new List<Image>();
    GameObject player;
    PlayerInput playerInput;
    Best bestAnim;
    bool change = true;


    private void Awake()
    {

        AdjustConfig adjustConfig = new AdjustConfig("zmxu75rywhs0", AdjustEnvironment.Sandbox);
        adjustConfig.setAppSecret(1, 1729091797, 541381912, 256436836, 850404545);
        Adjust.start(adjustConfig);

        string path = Application.persistentDataPath + "/Save";
        pooSpawn = FindObjectOfType<PooSpawn>();
        playerInput = FindObjectOfType<PlayerInput>();
        player = GameObject.Find("Player");
        bestAnim = FindObjectOfType<Best>();

        CreateSaveFile();
        LoadBestTime();




    }
    private void Start()
    {
        timeText.text = string.Format("Best Time : {0:N2}\n Time : {1:N2}", bestTime, time);
    }

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

        if (UIManager.Instance != null)
        {
            if (UIManager.Instance.gameStart == true)
            {
                time += Time.deltaTime;
                timeText.text = string.Format("Best Time : {0:N2}\n Time : {1:N2}", bestTime, time);
            }
        }


        if (time > bestTime)
        {

            bestTime = time;
            bestAnim.BestTime();
            SetBestTime();
        }


        if (time > (float)PooSpawn.diff.NormalHard)
        {
            if (change == true)
            {
                pooSpawn.different = PooSpawn.diff.Hard;
                change = false;
            }

        }
        else if (time > (float)PooSpawn.diff.Normal)
        {
            if (change == false)
            {
                sky.sprite = Resources.Load<Sprite>("AtlasTest/Hard/sky_hard");
                foreach (Image cloudes in cloud)
                {
                    int rand = Random.Range(1, 4);
                    cloudes.sprite = Resources.Load<Sprite>("AtlasTest/Hard/cloud0" + rand);
                }
                foreach (Image mountaines in mountain)
                {
                    int rand = Random.Range(1, 3);
                    mountaines.sprite = Resources.Load<Sprite>("AtlasTest/Hard/mountain0" + rand);
                }
                pooSpawn.different = PooSpawn.diff.NormalHard;
                change = true;
            }

        }
        else if (time > (float)PooSpawn.diff.EasyNormal)
        {
            if (change == true)
            {
                pooSpawn.different = PooSpawn.diff.Normal;
                change = false;
            }

        }
        else if (time > (float)PooSpawn.diff.Easy)
        {
            if (change != true)
            {
                sky.sprite = Resources.Load<Sprite>("AtlasTest/Normal/sky_normal");
                foreach (Image cloudes in cloud)
                {
                    int rand = Random.Range(1, 4);
                    cloudes.sprite = Resources.Load<Sprite>("AtlasTest/Normal/cloud0" + rand);
                }
                foreach (Image mountaines in mountain)
                {
                    int rand = Random.Range(1, 3);
                    mountaines.sprite = Resources.Load<Sprite>("AtlasTest/Normal/mountain0" + rand);
                }
                pooSpawn.different = PooSpawn.diff.EasyNormal;
                change = true;
            }

        }
        else
        {
            if (change == true)
            {
                pooSpawn.different = PooSpawn.diff.Easy;
                change = false;
            }

        }


    }

    private void SetBestTime()
    {
        string path = Application.persistentDataPath + "/Save";
        FileStream fs = new FileStream(path + "/score.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(bestTime);
        sw.Close();
    }

    private void LoadBestTime()
    {
        string path = Application.persistentDataPath + "/Save";
        FileStream fs = new FileStream(path + "/score.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        bestTime = float.Parse(sr.ReadLine());

        sr.Close();
    }

    static void CreateSaveFile()
    {
        string path = Application.persistentDataPath + "/Save";

        if (!Directory.Exists("Save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Save");
        }
        if (!File.Exists(Application.persistentDataPath + "/Save/score.txt"))
        {
            FileStream fs = new FileStream(Application.persistentDataPath + "/Save/score.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(bestTime);
            sw.Close();
        }

    }

    public void Die()
    {
        AdjustEvent rewarededAdEvent = new AdjustEvent("ptjpii");
        Adjust.trackEvent(rewarededAdEvent);
        Time.timeScale = 0;
        Vector2 shakePos = new Vector2(0.1f, 0f);

        player.transform.DOShakePosition(0.5f, shakePos, 20).SetUpdate(true);
        StartCoroutine(Player());

        
        playerInput.isGameOver = true;
    }

    public IEnumerator Player()
    {
        Vector2 size = new Vector2(0f, 0f);
        yield return new WaitForSecondsRealtime(1f);
        player.transform.DOScale(size, 0.5f).SetUpdate(true);
    }
}
