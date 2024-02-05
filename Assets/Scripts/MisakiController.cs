using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisakiController : MonoBehaviour
{
    Coroutine coroutine;
    void Start()
    {

    }

    void Update()
    {
        //ȭ���� Ŭ���ϸ� Ray�� �����.
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);
            RaycastHit hit;
            //���̿� �ݶ��̴� �浹üũ
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20f))
            {
                //�浹üũ �Ǹ� �浹 ���� ������
                Vector3 tpos = this.transform.position;
                tpos.x = hit.point.x;
                tpos.y = 0;
                tpos.z = hit.point.z;

                Debug.Log(tpos); //��ǥ��ġ
                                 //this.transform.position = tpos; //�̵��ϱ�
                //�ڷ�ƾ
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(CoMove(tpos));
            }

        }
    }

    IEnumerator CoMove(Vector3 tpos)
    {
        this.transform.LookAt(tpos); //�ٶ󺻴�
        while (true)
        {
            this.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
            float distance = (tpos - this.transform.position).magnitude;
            Debug.LogFormat("distance: {0}", distance);
            if (distance <= 0.1f)
            {
                break;
            }
            yield return null;
        }
        Debug.Log("�̵��Ϸ�");

        yield return null;
    }
}
