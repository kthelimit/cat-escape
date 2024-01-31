using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 100f;
    [SerializeField] private float jumpForce = 680f;

    [SerializeField] private ClimbCloudGameDirector gameDirector;
    private Animator anim;
    bool isCollission = false;
    [SerializeField] bool isContacted = false;

    private void Start()
    {
        //this.gameObject.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        //this.gameDirector = GameObject.Find("GameDirector").GetComponent<ClimbCloudGameDirector>();
        //this.gameDirector = GameObject.FindObjectOfType<ClimbCloudGameDirector>();
    }

    void Update()
    {
        //�����̽��ٸ� ������ 
        if (Input.GetKeyDown(KeyCode.Space) && isContacted)
        {
            //���� ���Ѵ�.
            this.rbody.AddForce(this.transform.up * this.jumpForce);
            //this.rbody.AddForce(Vector3.up * this.force);
            //�� �ΰ��� ���̰� �ִ�. ���� ĳ������ y������ ���ư��� �Ʒ��� ������ y��������� ���ư���.
        }

        //-1,0,1 : ����
        int dirX = 0;
        //���� ȭ��ǥŰ�� ������ �ִ� ���ȿ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
        }//���� ��������� �̷��� ����.

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
        }

        //Debug.Log(dirX);

        //����̰� �̵��ϴ� �������� �Ĵٺ���.
        //dirX�� 0�� �ƴҶ��� ���� �ٲٱ⸦ ����.
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        //������ ��
        //Debug.Log(this.transform.right * dirX); //����3

        //���� ! : �ӵ��� ��������
        // Mathf.Abs(this.rbody.velocity.x);
        // velocity.x�� 3�� �Ѿ�� �������°� ����.
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }
        //this.rbody.velocity = new Vector2(Mathf.Clamp(this.rbody.velocity.x, -3, 3), this.rbody.velocity.y);


        //�÷��̾� �̵��ӵ��� ���� �ִϸ��̼� �ӵ��� ��������.
        //anim.speed = this.rbody.velocity.x;
        anim.speed = Mathf.Abs(this.rbody.velocity.x) * 0.5f;
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
        //this.gameDirector.UpdateIsJumpingText(this.rbody.velocity);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -2.4f, 2.4f), this.transform.position.y, this.transform.position.z);
    }

    //Trigger����� ��� �浹 ������ ���ִ� �̺�Ʈ �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollission) return;
        isCollission = true;

        //���� �浹�Ҷ� �ѹ��� ȣ��
        Debug.LogFormat("OnTriggerEnter2D : {0}", collision);

        //����� ��ȯ
        SceneManager.LoadScene("ClimbCloudClear");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isContacted = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isContacted = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isContacted = false;
    }
}
