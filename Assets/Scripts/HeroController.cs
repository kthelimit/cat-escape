using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public int MaxHP { get; set; }
    public int Hp { get; set; }

    public System.Action onHit;

    private void Start()
    {
        MaxHP = 10;
        this.Hp = MaxHP;
        Debug.LogFormat("{0}/{1}", this.Hp, this.MaxHP);
    }
    void Update()
    {
        // ȭ���� Ŭ���ϸ� ���ظ� �޴´�
        if (Input.GetMouseButtonDown(0))
        {
            this.Hp -= 1;
            if (this.Hp <= 0)
            {
                this.Hp = 0;
            }
            Debug.LogFormat("{0}/{1}", this.Hp, this.MaxHP);
            this.onHit(); //�븮�� ȣ��
        }

    }
}
