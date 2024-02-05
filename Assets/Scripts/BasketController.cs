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
        //ȭ���� ��ġ�ϸ� ��ġ�� ��ġ�� �ٽ����� �����δ�.
        if (Input.GetMouseButtonDown(0))
        {
            //Ray�� �����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //�������� RaycastHit hit����
            RaycastHit hit;

            //if�� �ۼ� Physics.Raycast�� Ray�� �ݶ��̴��� �浹���� �� true�� ��ȯ, �׷��� ������ False ��ȯ��
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                if (hit.collider.gameObject.tag == "Apple" || hit.collider.gameObject.tag == "Bomb")
                {
                    return;
                }

                //���̿� �ݶ��̴��� �浹�ߴٸ�
                //�ٱ����� ��ġ�� �����δ�.
                int x = Mathf.RoundToInt(hit.point.x);
                int z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, hit.point.y, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("��Ҵ� => {0}", other.gameObject.tag);

        // other.CompareTag(tag)
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("����");
            AppleCatchGameDirector.Instance.GetApple();
            audioSource.PlayOneShot(appleSfx);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("����");
            AppleCatchGameDirector.Instance.GetBomb();
            audioSource.PlayOneShot(bombSfx);
        }
        Destroy(other.gameObject);
    }
}
