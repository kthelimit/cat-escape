using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    // 1. 마우스 왼쪽 클릭을 하면
    // 2. 회전한다.
        
    [SerializeField]
    private float maxSpeed = 2;
    [SerializeField]
    private float attenuation = 0.96f;
    private float speed = 0;

    void Update()
    {

        //static이라서 이렇게 써짐. 정적 메서드.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Down");
            speed = maxSpeed;
        }
        this.transform.Rotate(0, 0, speed);

        speed *= attenuation;
        Debug.Log(speed);
    }
}
