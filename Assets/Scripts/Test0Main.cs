using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0Main : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        //ȭ���� ��ġ�ϸ� ���콺 ��ġ�� �������
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                           //���� ��ġ, ����           ��          ����
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f) ;

            DrawArrow.ForDebug(ray.origin,ray.direction, 10, Color.red);
        }
    }
}
