using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField] GameObject bamsongiPrefab;


    void Update()
    {
        //화면 터치시 밤송이 생성
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 direct = Vector3.Normalize(ray.direction);            

            GameObject go = Instantiate(bamsongiPrefab);
            go.GetComponent<BamsongiController>().direct=direct;
                        
        }
    }
}
