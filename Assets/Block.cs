using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitPoints = 1; // �u���b�N�̑ϋv�l
    public Material hitMaterial; // �q�b�g���Ɍ��邽�߂̃}�e���A��
    private Material originalMaterial; // ���̃}�e���A��
    private Renderer blockRenderer;

    // Start is called before the first frame update
    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
        originalMaterial = blockRenderer.material; // ���̃}�e���A����ۑ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �Փ˔���
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitPoints--; // �ϋv�͂�����������

            // �q�b�g���Ɍ���
            StartCoroutine(Glow());

            if (hitPoints <= 0)
            {
                Destroy(this.gameObject); // �ϋv�͂�0�ȉ��ɂȂ�����u���b�N��j�󂷂�
            }
        }
    }

    public IEnumerator Glow()
    {
        blockRenderer.material = hitMaterial; // �q�b�g���̃}�e���A���ɕύX
        yield return new WaitForSeconds(0.1f); // 0.1�b�Ԍ���
        blockRenderer.material = originalMaterial; // ���̃}�e���A���ɖ߂�
    }
}
