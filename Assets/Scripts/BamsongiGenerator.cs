using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField] GameObject bamsongiPrefab;


    void Update()
    {
        //ȭ�� ��ġ�� ����� ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 direct = Vector3.Normalize(ray.direction);            

            GameObject go = Instantiate(bamsongiPrefab);
            go.GetComponent<BamsongiController>().direct=direct;
                        
        }
    }
}
