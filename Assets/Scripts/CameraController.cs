using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform tr;
    Transform playerTr;
    void Start()
    {
        tr = this.transform;
        playerTr = GameObject.Find("cat").GetComponent<Transform>();
    }

    void Update()
    {


        tr.position = new Vector3(tr.position.x, playerTr.position.y >= 1 ? playerTr.position.y : 1, tr.position.z);

    }
}
