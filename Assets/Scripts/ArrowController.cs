using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float attack = 10f;

    //�������� �����Ǵ� �ִ� ���� �ִ� ���� Assign�� �� ����.
    private CatEscapeGameDirector gameDirector;

    private GameObject playerGo;
    void Start()
    {
        //�̸����� ���ӿ�����Ʈ�� ã�´�.
        this.playerGo = GameObject.Find("player");
        //Ÿ������ ������Ʈ�� ã�´�.
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }


    void Update()
    { 

        //����*�ӵ�*�ð�
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        transform.Translate(movement);
       // Debug.LogFormat("y : {0}", this.transform.position.y);

        //���� y��ǥ�� -2.97���� �۾������� ������ �����Ѵ�.
        if (this.transform.position.y <= -2.97f)
        {
            //Debug.LogError("����!");
            //Destroy(this);//ArrowController�� �������.
            Destroy(this.gameObject); //���ӿ�����Ʈ�� ������ ����
        }

        //�Ÿ�

        Vector2 p1 = this.transform.position;
        Vector2 p2 = this.playerGo.transform.position;
        Vector2 dir = p1 - p2; //����
        float distance = dir.magnitude; //�Ÿ�

        //float distance = Vector2.Distance(p1, p2); //�Ȱ��� �Ÿ��� ��������!
        float r1 = this.radius;
        PlayerController controller = this.playerGo.GetComponent<PlayerController>();
        float r2 = controller.radius;
        float sumRadius = r1 + r2;

        if (distance < sumRadius) //�浹��(���ƴ�)
        {
            Debug.LogFormat("�浹�� : {0}, {1}", distance, sumRadius);
            Destroy(this.gameObject); //������ ����
            this.gameDirector.DecreaseHp(attack);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }

}