using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDataManager : MonoBehaviour
{
    public int Hp;
    public int maxHp;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void UpdateHeroHpAndMaxHp(int heroHP, int heroMaxHp)
    {
        Hp = heroHP;
        maxHp = heroMaxHp;
    }

    public int GetHeroHp()
    {
        return Hp;
    }

    public int GetHeroMaxHp()
    {
        return maxHp;
    }
}
