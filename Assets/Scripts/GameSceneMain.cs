using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneMain : MonoBehaviour
{
    [SerializeField] Text textHp;
    [SerializeField] private Button btnLoadScene;
    [SerializeField] GameObject heroPrefab;
    [SerializeField] HeroDataManager heroDataManager;
    void Start()
    {
        this.btnLoadScene.onClick.AddListener(() =>
        {
            Debug.Log("VillageScene으로 씬 전환 ");
            SceneManager.LoadScene("villageScene");
        });
        this.CreateHero();
    }

    private void CreateHero()
    {
        GameObject heroGo = Instantiate(this.heroPrefab);
        Debug.LogFormat("heroGo: {0}", heroGo);
        HeroController heroController = heroGo.GetComponent<HeroController>();
        //대리자야
        heroController.onHit = () =>
        {
            Debug.Log("영웅이 피해를 받았습니다");
            Debug.LogFormat("{0}/{1}", heroController.Hp, heroController.MaxHP);

            this.textHp.text = string.Format("{0}/{1}", heroController.Hp, heroController.MaxHP);
            heroDataManager.UpdateHeroHpAndMaxHp(heroController.Hp, heroController.MaxHP);


        };
    }

}
