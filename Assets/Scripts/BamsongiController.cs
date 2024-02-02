using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private Rigidbody rbody;
    private ParticleSystem particleSystem;
    public Vector3 direct;
    void Start()
    {
        //this.gameObject.GetComponent<Rigidbody>();
        this.rbody = this.GetComponent<Rigidbody>();
        this.particleSystem = this.GetComponent<ParticleSystem>();
        this.Shoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("OnCollisionEnter: {0}",collision.gameObject.name);
        rbody.isKinematic = true;
        //파티클시스템 컴포넌트 접근해서 Play 메서드 호출
        this.particleSystem.Play();
    }
    
    public void Shoot()
    {        
        this.rbody.AddForce(direct * 2000);
    }
}
