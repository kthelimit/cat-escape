using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject bombPrefab;
    float delta;
    [SerializeField] float timeLimit=2f;

    void Update()
    {
        delta += Time.deltaTime;
        //일정 시간 이후에 생성
        if (delta > timeLimit)
        {
            //랜덤하게 생성하기
            GameObject go = Instantiate(Random.Range(0,2)==1? applePrefab: bombPrefab);
            //위치도 랜덤
            go.transform.position = new Vector3(Random.Range(-1, 2), 3, Random.Range(-1, 2));
            delta = 0;
        }
    }
}
