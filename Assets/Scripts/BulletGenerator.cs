using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform playerTr;
    float delta;
    float timelimit = 0.07f;

    void Update()
    {
        delta += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (delta > timelimit)
            {
                GameObject go = Instantiate(bulletPrefab);
                go.transform.position = playerTr.GetChild(0).position;
                delta = 0f;
            }
        }
    }
}
