using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 100f;
    [SerializeField] private float jumpForce = 680f;

    [SerializeField] private ClimbCloudGameDirector gameDirector;

    private void Start()
    {
        //this.gameDirector = GameObject.Find("GameDirector").GetComponent<ClimbCloudGameDirector>();
        //this.gameDirector = GameObject.FindObjectOfType<ClimbCloudGameDirector>();
    }

    void Update()
    {
        //�����̽��ٸ� ������ 
        if (Input.GetKeyDown(KeyCode.Space))
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

        Debug.Log(dirX);

        //����̰� �̵��ϴ� �������� �Ĵٺ���.
        //dirX�� 0�� �ƴҶ��� ���� �ٲٱ⸦ ����.
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        //������ ��
        Debug.Log(this.transform.right * dirX); //����3

        //���� ! : �ӵ��� ��������
        // Mathf.Abs(this.rbody.velocity.x);
        // velocity.x�� 3�� �Ѿ�� �������°� ����.
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }
        //this.rbody.velocity = new Vector2(Mathf.Clamp(this.rbody.velocity.x, -3, 3), this.rbody.velocity.y);

        this.gameDirector.UpdateVelocityText(this.rbody.velocity);

    }
}
