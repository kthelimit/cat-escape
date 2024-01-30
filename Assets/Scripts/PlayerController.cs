using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float radius = 1f;
    private CatEscapeGameDirector gameDirector;
    void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    void Update()
    {
        if (this.gameDirector.playerHp <= 0)
            return;

        //키보드 입력을 받는 코드 작성
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽으로 2유닛만큼 이동");
            //x축으로 -2만큼 이동
            transform.Translate(-2, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽으로 2유닛만큼 이동");
            //x축으로 2만큼 이동
            transform.Translate(2, 0, 0);
        }
        Vector3 localPosition = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, transform.position.z);
        transform.position = localPosition;
    }

    //이벤트 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
