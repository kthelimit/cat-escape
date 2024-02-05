using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private AudioClip appleSfx;
    [SerializeField] private AudioClip bombSfx;
    private AudioSource audioSource;

    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();       
    }
    void Update()
    {
        //화면을 터치하면 터치한 위치로 바스켓을 움직인다.
        if (Input.GetMouseButtonDown(0))
        {
            //Ray를 만든다
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //지역변수 RaycastHit hit정의
            RaycastHit hit;

            //if문 작성 Physics.Raycast는 Ray와 콜라이더가 충돌했을 때 true를 반환, 그렇지 않으면 False 반환함
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                if (hit.collider.gameObject.tag == "Apple" || hit.collider.gameObject.tag == "Bomb")
                {
                    return;
                }

                //레이와 콜라이더가 충돌했다면
                //바구니의 위치를 움직인다.
                int x = Mathf.RoundToInt(hit.point.x);
                int z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, hit.point.y, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("잡았다 => {0}", other.gameObject.tag);

        // other.CompareTag(tag)
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("득점");
            AppleCatchGameDirector.Instance.GetApple();
            audioSource.PlayOneShot(appleSfx);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("감점");
            AppleCatchGameDirector.Instance.GetBomb();
            audioSource.PlayOneShot(bombSfx);
        }
        Destroy(other.gameObject);
    }
}
