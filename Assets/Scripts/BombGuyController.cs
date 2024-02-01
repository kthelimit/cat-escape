using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController : MonoBehaviour
{
    [SerializeField] Transform flagTransform;

    //BombGuyController�� Animator ������Ʈ�� �˾ƾ��Ѵ�.
    //��? �ִϸ��̼� ��ȯ�� �ؾ��ϱ� ������.
    //Animator ������Ʈ�� �ڽ� ������Ʈ anim�� �پ��ִ�.
    //��� �ϸ� �ڽ� ������Ʈ�� �پ��ִ� Animator ������Ʈ�� ������ �� ������?
    [SerializeField] Animator anim;
    [SerializeField] float speed = 5f;

    private Coroutine coroutine;
    public enum State
    {
        Idle, Run
    }

    private void Start()
    {
        //Transform animTransform = this.transform.Find("anim");
        //GameObject animGo = animTransform.gameObject;
        //this.anim = animGo.GetComponent<Animator>();
        //this.anim = GetComponentInChildren<Animator>();
        //�ڷ�ƾ �Լ� ȣ���
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.LogFormat("�̵��� ��� �Ϸ��߽��ϴ�.");
        }));
        //��ŸƮ�ڷ�ƾ ȣ���԰� ���ÿ� �ڷ�ƾ ��ȯ�ؼ� �� �ް�, �ڹ���� �˾Ƽ� ��������
        //ȣ���ڴ� this.StartCoroutine�̴�.

    }

    IEnumerator CoMove(System.Action callback)
    {
        // �� �����Ӹ��� ������ �̵�
        while (true)
        {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);
            //Vector3.Distance(transform.position, this.flagTransform.position);
            //�̷��� ��� �ȵ�
            float length = this.flagTransform.position.x - transform.position.x;
            //Debug.LogFormat("�̵���... ���� �Ÿ� : {0}",length);
            if (length < 1f)
            {
                break; //while���� �����.
            }
            yield return null; //���� ���������� �Ѿ��. �����ϸ� �ݺ��� �ȿ� ����.
        }
        Debug.Log("�̵��Ϸ�");
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Debug.Log("End CoMove");
        callback();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(this.coroutine);
        }


        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    //Debug.Log("Idle");
        //    // �ִϸ��̼� ��ȯ�ϱ�
        //    // ��ȯ �� �� �Ķ���Ϳ� ���� �����ϱ� 0
        //    anim.SetInteger("State", (int)State.Idle);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    //Debug.Log("Run");
        //    anim.SetInteger("State", (int)State.Run);
        //}
        // Move();


    }

    private void Move()
    {
        int dir = 0;
        //�̵�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
        }
        //�ִϸ��̼� ��Ʈ�ѷ�
        if (dir != 0)
        {
            this.transform.GetChild(0).localScale = new Vector3(dir, 1, 1);
            anim.SetInteger("State", (int)State.Run);
        }
        else
        {
            anim.SetInteger("State", (int)State.Idle);
        }
        transform.Translate(dir * speed * Time.deltaTime, 0, 0);
    }
}
