using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppleCatchClearMain : MonoBehaviour
{
    [SerializeField] Text appleText;
    [SerializeField] Text bombText;
    [SerializeField] Text scoreText;
    [SerializeField] Button reloadBtn;
    AppleCatchGameDataManager gameDataManager;
    AppleCatchGameDirector gameDirector;
    void Start()
    {
        gameDirector=GameObject.FindAnyObjectByType<AppleCatchGameDirector>();
        gameDataManager =GameObject.FindAnyObjectByType<AppleCatchGameDataManager>();
        appleText.text = "ȹ���� ��� : "+gameDataManager.appleCount.ToString()+"��";
        bombText.text = "���� ��ź : " + gameDataManager.bombCount.ToString() + "��";
        scoreText.text = "���� : " + gameDataManager.score.ToString();
        reloadBtn.onClick.AddListener(() => {           
            //Destroy(gameDataManager.gameObject);
            Destroy(gameDirector.gameObject);
            SceneManager.LoadScene("AppleCatchSelect");
        });
    }

}
