using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //������ ������ ������ ������ �ν��Ͻ��� �����.
    [SerializeField] private GameObject arrowPrefab;
    private CatEscapeGameDirector gameDirector;
    private float delta; // ����� �ð� ����

    private List<GameObject> arrowList;
    private void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
        arrowList= new List<GameObject>();
    }
    void Update()
    {
        if (this.gameDirector.playerHp <= 0)
        {
            DeleteArrows();
            return;
        }
            
        delta += Time.deltaTime; //���� �����Ӱ� ���� ������ ���� �ð�
       // Debug.Log(delta);
        if (delta > 3) //3�ʺ��� ũ�ٸ�
        {
            //����
            GameObject go = Instantiate(this.arrowPrefab);
            //��ġ �缳��
            float randX = Random.Range(-8, 9); // -8 ~ 8������

            go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);
            arrowList.Add(go);

            delta = 0; //��� �ð��� �ʱ�ȭ
        }
    }

    void DeleteArrows()
    {
        foreach (GameObject go in arrowList)
        {
            Destroy(go);
        }
    }
}
