using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenceSystem : MonoBehaviour
{
    public GameObject noteTap;
    public GameObject noteLong;
    AudioSource audioSource;
    MusicInfo musicInfo;
    public Button buttonPause, buttonSelectSong;
    public Text debugText;
    
    public static string songName;
    private int tapCounts = 0, longCounts = 0;  //tap and long list count
    private float startTime, displayTime;
    public static bool ispause = false, isEnd = false;

    //note list
    private List<float> tapSpawnTime = new List<float>();
    private List<int> tapSpawnDegree = new List<int>();
    private List<List<float>> longSpawnTime = new List<List<float>>();
    private List<int> longSpawnDegree = new List<int>();

    //fps system
    public static int fpsTarget = 60;
    public float updateInterval = 0.5f; 
    private float lastInterval;
    private int frames = 0;
    private float fps;

    void Start()
    {
        Debug.Log("initializing...");
        Application.targetFrameRate = fpsTarget;
        lastInterval = Time.realtimeSinceStartup;
        debugText.color = new Color(0, 255, 0, 100);
        isEnd = false;
        ComboText.count = 0;

        initialize();
        setTheStartTime();
    }

    void Update()
    {
        //fps system
        frames++;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow >= lastInterval + updateInterval)
        {
            fps = frames / (timeNow - lastInterval);
            frames = 0;
            lastInterval = timeNow;
        }

        if (!ispause)
        {
            displayTime = Time.time - startTime;

            //debug
            if (GameSetting.debugMode)
            {
                debugText.text = "Display Time\t" + displayTime.ToString() 
                    + "\n Taps Count\t" + tapCounts 
                    + "\n musictimediff\t" + (audioSource.time - displayTime) 
                    + "\n FPS:\t" + fps;
            }
            //Force Correction 
            if (System.Math.Abs(audioSource.time - displayTime - ((musicInfo.offset + GameSetting.offset2) / 1000f)) > 0.2f)
            {
                setTheStartTime();
            }

            if(tapSpawnTime.Count - 1 > tapCounts)
            {
                Debug.Log("tapCounts" + tapCounts);
                Debug.Log("tapSpawnTime" + tapSpawnTime.Count);
                if (displayTime > tapSpawnTime[tapCounts] && displayTime < tapSpawnTime[tapCounts + 1])
                {
                    SpawnTap(tapSpawnDegree[tapCounts]);
                    tapCounts++;
                }
            }
            
            if(longSpawnTime.Count - 1 > longCounts)
            {
                if (displayTime > longSpawnTime[longCounts][0])
                {
                    SpawnLong(longSpawnDegree[longCounts], (int)longSpawnTime[longCounts][1]);
                    longCounts++;
                }
            }
            
            if (audioSource.clip.length - audioSource.time < 0.2)
            {
                isEnd = true;
            }
        }

        //Debug.Log(isEnd);
        if (isEnd)
        {
            SceneManager.LoadScene("score");
        }
    }

    void initialize()
    {
        songName = GameSetting.title;
        displayTime = 0f;
        frames = 0;
        GameSetting.judgeCount = new int[] { 0, 0, 0 };

        TextAsset txtAsset = (TextAsset)Resources.Load("song_data/" + songName, typeof(TextAsset));
        Debug.Log(songName);
        string data = txtAsset.text;
        musicInfo = JsonUtility.FromJson<MusicInfo>(data);

        NotesFormate.formates(data, 60);
        tapSpawnTime = NotesFormate.getTapSpawnTime();
        tapSpawnDegree = NotesFormate.getTapSpawnDegree();
        longSpawnTime = NotesFormate.getLongSpawnTime();
        longSpawnDegree = NotesFormate.getLongSpawnDegree();

        audioSource = GameObject.Find(songName).GetComponent<AudioSource>();
        audioSource.Play();

        Debug.Log("initialize complete");
    }

    public void setTheStartTime()
    {
        Debug.Log("setTheStartTime");
        startTime = Time.time - (audioSource.time - musicInfo.offset / 1000f);
        displayTime = Time.time - startTime;
        audioSource.Play();

        for (int i = 0; i < tapSpawnTime.Count; i++)
        {
            if (tapSpawnTime[i] < displayTime)
            {
                tapCounts = i;
                break;
            }
            else
            {
                tapCounts = 0;
            }
        }

        for (int i = 0; i < longSpawnTime.Count; i++)
        {
            if (longSpawnTime[i][0] < displayTime)
            {
                longCounts = i;
                break;
            }
            else
            {
                longCounts = 0;
            }
        }
    }

    public void OnPauseBtn()
    {
        if (ispause)
        {
            setTheStartTime();
            audioSource.Play();
            ispause = false;
        }
        else
        {
            ispause = true;
            audioSource.Pause();
        }
    }

    private void SpawnTap(int spawnDegree)
    {
        if (spawnDegree != -1)
        {
            try
            {
                //Debug.Log(spawnDegree);
                if (spawnDegree >= 0)
                {
                    spawnDegree = spawnDegree >= 360 ? spawnDegree % 360 : spawnDegree;
                    float fl = spawnDegree * Mathf.PI / 180.0f;
                    GameObject Obj = Instantiate(noteTap);
                    Obj.transform.position = new Vector2(Mathf.Sin(fl), Mathf.Cos(fl)) * 5;
                    Obj.name = "tap" + displayTime.ToString();
                }
            }
            catch (System.FormatException e)
            {
                Debug.LogError(e);
            }
        }
    }

    private void SpawnLong(int spawnDegree, int endFrame)
    {
        if (spawnDegree != -1)
        {
            try
            {
                if (spawnDegree >= 0)
                {
                    spawnDegree = spawnDegree >= 360 ? spawnDegree % 360 : spawnDegree;
                    float fl = spawnDegree * Mathf.PI / 180.0f;
                    GameObject Obj2 = Instantiate(noteLong);
                    Obj2.transform.position = new Vector2(Mathf.Sin(fl), Mathf.Cos(fl)) * 5;
                    Obj2.name = "long" + endFrame + "/" + spawnDegree;
                }
            }
            catch (System.FormatException e)
            {
                Debug.LogError(e);
            }
        }
    }
}

