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
        //왼쪽 버튼을 눌렀다면
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("화면 터치 시작");
            //화면을 터치한 위치 가져오기
            //Debug.Log(Input.mousePosition);
            this.startPosition = Input.mousePosition;
            //speed = maxSpeed;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("화면에서 손을 뗌");
            //Debug.Log(Input.mousePosition);
            float length = Input.mousePosition.x - this.startPosition.x;
            //Debug.Log(length);
            //Debug.Log(length / divide);
            speed = length / divide;
            //Debug.LogFormat("<color=yellow>speed : {0}</color>", speed);
            //화면에서 손을 뗀 지점의 x - 터치한 지점의 x
            //사운드 실행

            //게임오브젝트에 붙어있는 컴포넌트 가져오기
            //this. gameObject.GetComponent<AudioSource>()
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //0.1유닛씩 매 프레임마다 이동한다.
        this.gameObject.transform.Translate(new Vector3(speed, 0, 0));
        //매 프레임마다 스피드를 감속한다.
        speed *= attenuation;
    }
}
