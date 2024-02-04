using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPirate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�¾Ҵ�!");
            collision.transform.GetComponent<CaptainController>().GetHit();
        }

    }
}
