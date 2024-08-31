using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBlock : Block
{
    public GameObject ballPrefab; // �V�����{�[����Prefab

    // �Փ˔�����I�[�o�[���C�h
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitPoints--; // �ϋv�͂�����������

            // �q�b�g���Ɍ���
            StartCoroutine(Glow());

            if (hitPoints <= 0)
            {
                // �u���b�N��j�󂷂�O�Ƀ{�[����2�ɑ��₷
                SplitBall(collision.gameObject);
                Destroy(this.gameObject); // �ϋv�͂�0�ȉ��ɂȂ�����u���b�N��j�󂷂�
            }
        }
    }

    private void SplitBall(GameObject originalBall)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // �V�����{�[����2����
        for (int i = 0; i < 2; i++)
        {
            GameObject newBall = Instantiate(ballPrefab, originalBall.transform.position, Quaternion.identity);
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            // �V�����{�[���Ƀ����_���ȕ����Ƒ��x��^����
            rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized * originalBall.GetComponent<Ball>().speed;

            // �Q�[���}�l�[�W���[�Ƀ{�[�����������ꂽ���Ƃ�ʒm
            gameManager.BallCreated();
        }
    }
}