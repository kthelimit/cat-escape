using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VilageSceneMain : MonoBehaviour
{
    private HeroDataManager heroDataManager;
    [SerializeField] Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        heroDataManager = GameObject.FindAnyObjectByType<HeroDataManager>();
        Debug.LogFormat("{0}/{1}", this.heroDataManager.GetHeroHp(), this.heroDataManager.GetHeroMaxHp());
        hpText.text = string.Format("{0}/{1}", this.heroDataManager.GetHeroHp(), this.heroDataManager.GetHeroMaxHp());
    
    }
}
