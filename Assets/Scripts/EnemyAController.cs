using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    Coroutine coroutine;
    private void Start()
    {
        coroutine= StartCoroutine(CoMove());
    }
    IEnumerator CoMove()
    {
        while (true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1.5f);
            yield return null;
            if(transform.position.y<=-5.19f)
            {
                break;
            }
        }
        Delete();
    }

    [SerializeField] GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            Explode();
        }
    }
    void Delete()
    {
        Destroy(gameObject);
    }
    void Explode()
    {
        GameObject go = Instantiate(explosionPrefab);
        go.transform.position = transform.position;
        Destroy(go, 0.3f);
        StopCoroutine(coroutine);
        Destroy(gameObject);
    }
}
