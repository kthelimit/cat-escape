using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppleCatchGameDirector : MonoBehaviour
{
    public static AppleCatchGameDirector Instance;
    [SerializeField] Text timeText;
    [SerializeField] float leftTime = 60;
    [SerializeField] Text scoreText;
    [SerializeField] float score = 0;
    [SerializeField] int appleCount = 0;
    [SerializeField] int bombCount = 0;

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
        appleCount++;
        UpdateScore();
    }

    public void GetBomb()
    {
        score *= 0.5f;
        bombCount++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Á¡¼ö : " + ((int)score).ToString();
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
