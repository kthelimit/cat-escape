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
        //���� �ð� ���Ŀ� ����
        if (delta > timeLimit)
        {
            //�����ϰ� �����ϱ�
            GameObject go = Instantiate(Random.Range(0,2)==1? applePrefab: bombPrefab);
            //��ġ�� ����
            go.transform.position = new Vector3(Random.Range(-1, 2), 3, Random.Range(-1, 2));
            delta = 0;
        }
    }
}
