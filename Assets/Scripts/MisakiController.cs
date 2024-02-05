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
        //화면을 클릭하면 Ray를 만든다.
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 10);
            RaycastHit hit;
            //레이와 콜라이더 충돌체크
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20f))
            {
                //충돌체크 되면 충돌 정보 얻어오기
                Vector3 tpos = this.transform.position;
                tpos.x = hit.point.x;
                tpos.y = 0;
                tpos.z = hit.point.z;

                Debug.Log(tpos); //목표위치
                                 //this.transform.position = tpos; //이동하기
                //코루틴
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
        this.transform.LookAt(tpos); //바라본다
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
        Debug.Log("이동완료");

        yield return null;
    }
}
