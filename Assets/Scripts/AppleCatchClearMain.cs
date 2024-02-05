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
        appleText.text = "È¹µæÇÑ »ç°ú : "+gameDataManager.appleCount.ToString()+"°³";
        bombText.text = "¸ÂÀº ÆøÅº : " + gameDataManager.bombCount.ToString() + "°³";
        scoreText.text = "Á¡¼ö : " + gameDataManager.score.ToString();
        reloadBtn.onClick.AddListener(() => {           
            //Destroy(gameDataManager.gameObject);
            Destroy(gameDirector.gameObject);
            SceneManager.LoadScene("AppleCatchSelect");
        });
    }

}
