using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainController : MonoBehaviour
{
    public enum State
    {
        Idle, Hit, Dead
    }
    public float hp = 2f;
    private float maxHp = 2f;
    [SerializeField] Animator anim;
    void Start()
    {
        this.anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

    }

    public void GetHit()
    {
        hp--;
        anim.SetTrigger("isHit");
        if (hp<=0)
        {
            Dead();
        }        
    }

    private void Dead()
    {
        anim.SetTrigger("isDead");
        Destroy(this.gameObject, 0.5f);
    }
}
