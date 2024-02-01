using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController2 : MonoBehaviour
{
    public enum State
    {
        Idle, Run, Jump
    }
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rbody;
    [SerializeField] float jumpForce = 200f;
    [SerializeField] float runForce = 200f;
    [SerializeField] bool isJump = false;
    bool isAttack = false;

    void Start()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ThrowBomb();
        }
        if (!isAttack)
        {
            Move();
        }
        CheckJump();
    }

    private void CheckJump()
    {
        if (this.rbody.velocity.y == 0)
        {
            isJump = false;
        }
        else
        {
            isJump = true;
        }
    }

    private void Move()
    {
        int dir = 0;
        //이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            this.rbody.AddForce(this.transform.up * jumpForce);
        }
        //애니메이션 컨트롤러
        if (dir != 0)
        {
            this.transform.GetChild(0).localScale = new Vector3(dir, 1, 1);
            anim.SetInteger("State", (int)State.Run);
        }
        else
        {
            anim.SetInteger("State", (int)State.Idle);
        }
        if (Mathf.Abs(rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dir * runForce);
        }
    }

    private void ThrowBomb()
    {
        Debug.Log("던진다 폭탄~!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            collision.transform.GetComponent<CaptainController>().GetHit();
        }
    }
}
