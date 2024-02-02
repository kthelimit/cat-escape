using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    float h;
    float v;
    [SerializeField] float speed = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        transform.Translate((h * Vector2.right + v * Vector2.up).normalized * Time.deltaTime * speed);
        anim.SetInteger("Direction", (int)h);
    }
}
