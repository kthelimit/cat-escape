using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    Coroutine coroutine;
    private void Start()
    {
        coroutine= StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return null;

            //���� ���� �̻� �ö󰡸� ���� ��
            if (transform.position.y >= 6.50)
            {
                break;
            }           
        }
        //����
        DeleteBullet();
    }

    void DeleteBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine(coroutine);
        DeleteBullet();
    }
}
