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
            Debug.Log("VillageScene���� �� ��ȯ ");
            SceneManager.LoadScene("villageScene");
        });
        this.CreateHero();
    }

    private void CreateHero()
    {
        GameObject heroGo = Instantiate(this.heroPrefab);
        Debug.LogFormat("heroGo: {0}", heroGo);
        HeroController heroController = heroGo.GetComponent<HeroController>();
        //�븮�ھ�
        heroController.onHit = () =>
        {
            Debug.Log("������ ���ظ� �޾ҽ��ϴ�");
            Debug.LogFormat("{0}/{1}", heroController.Hp, heroController.MaxHP);

            this.textHp.text = string.Format("{0}/{1}", heroController.Hp, heroController.MaxHP);
            heroDataManager.UpdateHeroHpAndMaxHp(heroController.Hp, heroController.MaxHP);


        };
    }

}
