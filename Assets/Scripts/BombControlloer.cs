using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControlloer : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float time = 2f;
    void Start()
    {
        StartCoroutine(Explosion());
    }


    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(time);
        GameObject go = Instantiate(explosionPrefab);
        go.transform.position = transform.position;
        Destroy(go, 0.3f);
        Destroy(gameObject);
    }

}
