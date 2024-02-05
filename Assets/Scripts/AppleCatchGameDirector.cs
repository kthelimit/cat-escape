using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppleCatchGameDirector : MonoBehaviour
{
    public static AppleCatchGameDirector Instance;
    AppleCatchGameDataManager gameDataManager;
    [SerializeField] Text timeText;
    [SerializeField] float leftTime = 60;
    [SerializeField] Text scoreText;
    [SerializeField] float score = 0;

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
        gameDataManager = GameObject.FindAnyObjectByType<AppleCatchGameDataManager>();
    }
    private void Start()
    {
        timeText = GameObject.Find("timeCount").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        leftTime = 60f;
        score = 0;
        UpdateScore();
    }
 
    // Update is called once per frame
    void Update()
    {
        leftTime -= Time.deltaTime;
        UpdateTime();
    }

    public void GetApple()
    {
        score += 100f;
        gameDataManager.appleCount++;
        UpdateScore();
    }

    public void GetBomb()
    {
        score *= 0.5f;
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
        if (timeText == null)
        {
            return;
        }
        timeText.text = t.Substring(0, 5);
        if (leftTime <= 0)
        {
            SceneManager.LoadScene("AppleCatchClear");
        }
    }


}
