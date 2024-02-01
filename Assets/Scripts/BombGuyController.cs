using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuyController : MonoBehaviour
{
    [SerializeField] Transform flagTransform;

    //BombGuyController가 Animator 컴포넌트를 알아야한다.
    //왜? 애니메이션 전환을 해야하기 때문에.
    //Animator 컴포넌트는 자식 오브젝트 anim에 붙어있다.
    //어떻게 하면 자식 오브젝트에 붙어있는 Animator 컴포넌트를 가져올 수 있을까?
    [SerializeField] Animator anim;
    [SerializeField] float speed = 5f;

    private Coroutine coroutine;
    public enum State
    {
        Idle, Run
    }

    private void Start()
    {
        //Transform animTransform = this.transform.Find("anim");
        //GameObject animGo = animTransform.gameObject;
        //this.anim = animGo.GetComponent<Animator>();
        //this.anim = GetComponentInChildren<Animator>();
        //코루틴 함수 호출시
        this.coroutine = this.StartCoroutine(this.CoMove(() =>
        {
            Debug.LogFormat("이동을 모두 완료했습니다.");
        }));
        //스타트코루틴 호출함과 동시에 코루틴 반환해서 값 받고, 코무브는 알아서 돌고있음
        //호출자는 this.StartCoroutine이다.

    }

    IEnumerator CoMove(System.Action callback)
    {
        // 매 프레임마다 앞으로 이동
        while (true)
        {
            this.transform.Translate(transform.right * 1f * Time.deltaTime);
            //Vector3.Distance(transform.position, this.flagTransform.position);
            //이렇게 재면 안됨
            float length = this.flagTransform.position.x - transform.position.x;
            //Debug.LogFormat("이동중... 남은 거리 : {0}",length);
            if (length < 1f)
            {
                break; //while문을 벗어난다.
            }
            yield return null; //다음 프레임으로 넘어간다. 가능하면 반복문 안에 넣자.
        }
        Debug.Log("이동완료");
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Debug.Log("End CoMove");
        callback();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(this.coroutine);
        }


        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    //Debug.Log("Idle");
        //    // 애니메이션 전환하기
        //    // 전환 할 때 파라미터에 값을 변경하기 0
        //    anim.SetInteger("State", (int)State.Idle);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    //Debug.Log("Run");
        //    anim.SetInteger("State", (int)State.Run);
        //}
        // Move();


    }

    private void Move()
    {
        int dir = 0;
        //이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
        }
        //애니메이션 컨트롤러
        if (dir != 0)
        {
            this.transform.GetChild(0).localScale = new Vector3(dir, 1, 1);
            anim.SetInteger("State", (int)State.Run);
        }
        else
        {
            anim.SetInteger("State", (int)State.Idle);
        }
        transform.Translate(dir * speed * Time.deltaTime, 0, 0);
    }
}
