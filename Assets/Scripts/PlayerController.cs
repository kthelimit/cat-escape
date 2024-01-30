using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float radius = 1f;
    private CatEscapeGameDirector gameDirector;
    [SerializeField] Button btnLeft;
    [SerializeField] Button btnRight;

    void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
        //this.btnLeft.onClick.AddListener(this.LeftButtonClick);
        //this.btnRight.onClick.AddListener(this.RightButtonClick);

        this.btnLeft.onClick.AddListener(() => {
            Debug.Log("���� ȭ��ǥ ��ư Ŭ��");
            transform.Translate(-2, 0, 0);
        });
        this.btnRight.onClick.AddListener(() => {
            Debug.Log("������ ȭ��ǥ ��ư Ŭ��");
            transform.Translate(2, 0, 0);
        });
    }

    void Update()
    {
        if (this.gameDirector.playerHp <= 0)
            return;

        //Ű���� �Է��� �޴� �ڵ� �ۼ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("�������� 2���ָ�ŭ �̵�");
            //x������ -2��ŭ �̵�
            transform.Translate(-2, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("���������� 2���ָ�ŭ �̵�");
            //x������ 2��ŭ �̵�
            transform.Translate(2, 0, 0);
        }
        Vector3 localPosition = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, transform.position.z);
        transform.position = localPosition;
    }

    //�̺�Ʈ �Լ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }

    public void LeftButtonClick()
    {
        Debug.Log("Left Button Clicked!");
    }

    public void RightButtonClick()
    {
        Debug.Log("Right Button Clicked!");
    }
}
