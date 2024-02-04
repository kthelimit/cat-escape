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
    [SerializeField] float runForce = 2f;
    [SerializeField] bool isJump = false;
    [SerializeField] bool isAttack = false;
    [SerializeField] GameObject bombPrefab;
    float h;

    void Start()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowBomb();
        }
        Move();


        CheckJump();
    }

    private void CheckJump()
    {
        if (this.rbody.velocity.y >= -0.1f&& this.rbody.velocity.y <= 0.1f)
        {
            isJump = false;
        }
        else
        {
            anim.SetInteger("State", (int)State.Jump);
            isJump = true;
        }
    }

    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");

        int dir = (int)h;
        //����
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {            
            this.rbody.AddForce(this.transform.up * jumpForce);            
        }
        //�ִϸ��̼� ��Ʈ�ѷ�
        if (dir != 0 && !isJump)
        {
            this.transform.GetChild(0).localScale = new Vector3(dir, 1, 1);
            anim.SetInteger("State", (int)State.Run);
        }
        else if (!isJump)
        {
            anim.SetInteger("State", (int)State.Idle);
        }
        //�̵�
        if (!isAttack)
        {
            this.transform.Translate(Vector2.right * h * Time.deltaTime * runForce);
        }
    }

    private void ThrowBomb()
    {
        isAttack = true;
        anim.SetTrigger("Attack");
        Debug.Log("������ ��ź~!");
        GameObject go = Instantiate(bombPrefab);
        go.transform.position = transform.position;
        isAttack = false;
        Debug.Log(isAttack);
    }

}
