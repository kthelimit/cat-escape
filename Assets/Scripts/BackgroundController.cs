using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    Vector3 originPos;
    [SerializeField]GameObject image1;
    [SerializeField]GameObject image2;
    [SerializeField] float speed = 2f;
    void Start()
    {
        image1 = transform.GetChild(0).gameObject;
        originPos = image1.transform.position;
        image2 = transform.GetChild(1).gameObject;
        StartCoroutine(CoMove());
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            image1.transform.Translate(Vector3.down * speed * Time.deltaTime);
            image2.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (image1.transform.position.y <= originPos.y - 11.73 * 2)
            {
                image1.transform.position = originPos;
            }
            if (image2.transform.position.y <= originPos.y - 11.73 * 2)
            {
                image2.transform.position = originPos;
            }
            yield return null;
        }
    }
}
