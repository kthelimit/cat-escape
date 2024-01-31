using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float moveForce = 100f;
    [SerializeField] private float jumpForce = 680f;

    [SerializeField] private ClimbCloudGameDirector gameDirector;
    private Animator anim;
    bool isCollission = false;
    [SerializeField] bool isContacted = false;

    private void Start()
    {
        //this.gameObject.GetComponent<Animator>();
        anim = GetComponent<Animator>();
        //this.gameDirector = GameObject.Find("GameDirector").GetComponent<ClimbCloudGameDirector>();
        //this.gameDirector = GameObject.FindObjectOfType<ClimbCloudGameDirector>();
    }

    void Update()
    {
        //스페이스바를 누르면 
        if (Input.GetKeyDown(KeyCode.Space) && isContacted)
        {
            //힘을 가한다.
            this.rbody.AddForce(this.transform.up * this.jumpForce);
            //this.rbody.AddForce(Vector3.up * this.force);
            //이 두개는 차이가 있다. 위는 캐릭터의 y축으로 날아가고 아래는 세계의 y축방향으로 날아간다.
        }

        //-1,0,1 : 방향
        int dirX = 0;
        //왼쪽 화살표키를 누르고 있는 동안에
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
        }//조금 길어지더라도 이렇게 적자.

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
        }

        //Debug.Log(dirX);

        //고양이가 이동하는 방향쪽을 쳐다보기.
        //dirX가 0이 아닐때만 방향 바꾸기를 하자.
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }

        //벡터의 곱
        //Debug.Log(this.transform.right * dirX); //벡터3

        //도전 ! : 속도를 제한하자
        // Mathf.Abs(this.rbody.velocity.x);
        // velocity.x가 3을 넘어가면 빨라지는거 같다.
        if (Mathf.Abs(this.rbody.velocity.x) < 3)
        {
            this.rbody.AddForce(this.transform.right * dirX * moveForce);
        }
        //this.rbody.velocity = new Vector2(Mathf.Clamp(this.rbody.velocity.x, -3, 3), this.rbody.velocity.y);


        //플레이어 이동속도에 따라 애니메이션 속도를 조절하자.
        //anim.speed = this.rbody.velocity.x;
        anim.speed = Mathf.Abs(this.rbody.velocity.x) * 0.5f;
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
        //this.gameDirector.UpdateIsJumpingText(this.rbody.velocity);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -2.4f, 2.4f), this.transform.position.y, this.transform.position.z);
    }

    //Trigger모드일 경우 충돌 판정을 해주는 이벤트 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollission) return;
        isCollission = true;

        //최초 충돌할때 한번만 호출
        Debug.LogFormat("OnTriggerEnter2D : {0}", collision);

        //장면을 전환
        SceneManager.LoadScene("ClimbCloudClear");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isContacted = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isContacted = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isContacted = false;
    }
}
