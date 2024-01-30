using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text������ �������.

public class GameDirector : MonoBehaviour
{
    private GameObject carGo;
    private GameObject flagGo;
    private GameObject distanceGo;
    private Text distanceText;
    void Start()
    {
        //Find�� ���� �޼���.
        this.carGo = GameObject.Find("car");
        //Debug.LogFormat("this.carGo:{0}", this.carGo); //car ���ӿ�����Ʈ�� �ν��Ͻ�
        this.flagGo = GameObject.Find("flag");
        //Debug.LogFormat("this.flagGo:{0}", this.flagGo); //flag ���ӿ�����Ʈ�� �ν��Ͻ�
        this.distanceGo = GameObject.Find("distance");
        Debug.LogFormat("this.distanceGo:{0}", this.distanceGo); // �Ÿ�ǥ�ÿ� �ؽ�Ʈ(distance) ���ӿ�����Ʈ�� �ν��Ͻ�
        distanceText = distanceGo.GetComponent<Text>();
        Debug.LogFormat("distanceText:{0}", distanceText);
        distanceText.text = "�ȳ��ϼ���";


    }

    void Update()
    {
        //�������Ӹ��� �ڵ����� ����� �Ÿ��� ���
        float length = this.flagGo.transform.position.x - this.carGo.transform.position.x;
        Debug.Log(length);
        distanceText.text = "���� �Ÿ� : " + length.ToString("0.00") + "m"; 
    }
}
