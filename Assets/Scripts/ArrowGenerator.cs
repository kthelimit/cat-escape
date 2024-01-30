using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //프리팹 에셋을 가지고 프리팹 인스턴스를 만든다.
    [SerializeField] private GameObject arrowPrefab;
    private CatEscapeGameDirector gameDirector;
    private float delta; // 경과된 시간 변수

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
            
        delta += Time.deltaTime; //이전 프레임과 현재 프레임 사이 시간
       // Debug.Log(delta);
        if (delta > 3) //3초보다 크다면
        {
            //생성
            GameObject go = Instantiate(this.arrowPrefab);
            //위치 재설정
            float randX = Random.Range(-8, 9); // -8 ~ 8까지임

            go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);
            arrowList.Add(go);

            delta = 0; //경과 시간을 초기화
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
