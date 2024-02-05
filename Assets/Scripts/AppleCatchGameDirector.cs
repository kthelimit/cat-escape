using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppleCatchGameDirector : MonoBehaviour
{
    public static AppleCatchGameDirector Instance;
    [SerializeField] AppleCatchGameDataManager gameDataManager;
    [SerializeField] Text timeText;
    [SerializeField] float leftTime = 0;
    [SerializeField] Text scoreText;
    [SerializeField] float score = 0;

    public static System.Action OnBasketColor;

    private void Awake()
    {
        
        if (AppleCatchGameDirector.Instance == null)
        {
            AppleCatchGameDirector.Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        timeText = GameObject.Find("timeCount").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        gameDataManager = FindAnyObjectByType<AppleCatchGameDataManager>();
        ResetGame();
        UpdateScore();
    }
 
    void Update()
    {
        leftTime -= Time.deltaTime;
        UpdateTime();
    }

    void ResetGame()
    {
        leftTime = gameDataManager.leftTimeMax;
        score = 0;
        UpdateScore();
    }

    public void GetApple()
    {
        score += gameDataManager.appleScore;
        gameDataManager.appleCount++;
        UpdateScore();
    }

    public void GetBomb()
    {
        score *= gameDataManager.bombPenalty;
        gameDataManager.bombCount++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Á¡¼ö : " + ((int)score).ToString();
        gameDataManager.score = this.score;
    }

    void UpdateTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(leftTime);
        string t = string.Format("{0:00}:{1:00}", timeSpan.Seconds, timeSpan.Milliseconds);
        timeText.text = t.Substring(0, 5);
        if (leftTime <= 0)
        {
            SceneManager.LoadScene("AppleCatchClear");
        }
    }


}
