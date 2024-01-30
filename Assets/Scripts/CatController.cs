using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float force = 680f;

    void Update()
    {
        //스페이스바를 누르면 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //힘을 가한다.
            this.rbody.AddForce(this.transform.up * this.force);
            //this.rbody.AddForce(Vector3.up * this.force);
            //이 두개는 차이가 있다. 위는 캐릭터의 y축으로 날아가고 아래는 세계의 y축방향으로 날아간다.
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.rbody.AddForce(-this.transform.right * this.force * 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.rbody.AddForce(this.transform.right * this.force * 0.1f);
        }

    }
}
