using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float force = 680f;

    void Update()
    {
        //�����̽��ٸ� ������ 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //���� ���Ѵ�.
            this.rbody.AddForce(this.transform.up * this.force);
            //this.rbody.AddForce(Vector3.up * this.force);
            //�� �ΰ��� ���̰� �ִ�. ���� ĳ������ y������ ���ư��� �Ʒ��� ������ y��������� ���ư���.
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.rbody.AddForce(-this.transform.right * this.force * 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.rbody.AddForce(this.transform.right * this.force * 0.1f);
        }

    }
}
