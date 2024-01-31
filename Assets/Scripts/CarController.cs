using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // [SerializeField]
    //private float maxSpeed = 0.1f;
    [SerializeField]
    private float attenuation = 0.96f;
    [SerializeField]
    private float divide = 500f;
    private float speed = 0;

    private Vector3 startPosition;
    void Start()
    {

    }

    void Update()
    {
        //���� ��ư�� �����ٸ�
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("ȭ�� ��ġ ����");
            //ȭ���� ��ġ�� ��ġ ��������
            //Debug.Log(Input.mousePosition);
            this.startPosition = Input.mousePosition;
            //speed = maxSpeed;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("ȭ�鿡�� ���� ��");
            //Debug.Log(Input.mousePosition);
            float length = Input.mousePosition.x - this.startPosition.x;
            //Debug.Log(length);
            //Debug.Log(length / divide);
            speed = length / divide;
            //Debug.LogFormat("<color=yellow>speed : {0}</color>", speed);
            //ȭ�鿡�� ���� �� ������ x - ��ġ�� ������ x
            //���� ����

            //���ӿ�����Ʈ�� �پ��ִ� ������Ʈ ��������
            //this. gameObject.GetComponent<AudioSource>()
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //0.1���־� �� �����Ӹ��� �̵��Ѵ�.
        this.gameObject.transform.Translate(new Vector3(speed, 0, 0));
        //�� �����Ӹ��� ���ǵ带 �����Ѵ�.
        speed *= attenuation;
    }
}
