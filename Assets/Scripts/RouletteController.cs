using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    // 1. ���콺 ���� Ŭ���� �ϸ�
    // 2. ȸ���Ѵ�.
        
    [SerializeField]
    private float maxSpeed = 2;
    [SerializeField]
    private float attenuation = 0.96f;
    private float speed = 0;

    void Update()
    {

        //static�̶� �̷��� ����. ���� �޼���.
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
