using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatEscapeGameDirector : MonoBehaviour
{

    [SerializeField] private Image hpGauge;
    public float playerHp = 100f;
    [SerializeField] private float maxHp = 100f;

    public void DecreaseHp(float attack)
    {
        playerHp -= attack;
        this.hpGauge.fillAmount = playerHp / maxHp;
    }
}
