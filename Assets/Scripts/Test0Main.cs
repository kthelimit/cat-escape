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
        //화면을 터치하면 마우스 위치를 출력하자
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                           //시작 위치, 방향           색          길이
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f) ;

            DrawArrow.ForDebug(ray.origin,ray.direction, 10, Color.red);
        }
    }
}
