using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 3.0f;  // �{�[���̃X�s�[�h
    private Rigidbody rb;       // Rigidbody�R���|�[�l���g
    private GameObject gameManager; // GameManager�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody�R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
        // �{�[���ɏ�����^����
        rb.velocity = (transform.forward + transform.right) * speed;
        // GameManager�I�u�W�F�N�g���擾
        gameManager = GameObject.Find("GameManager");
        // �Q�[���}�l�[�W���[�Ƀ{�[�����������ꂽ���Ƃ�ʒm
        gameManager.GetComponent<GameManager>().BallCreated();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gameover")
        {
            // �{�[�����폜����O��GameManager�ɒʒm
            gameManager.GetComponent<GameManager>().BallDestroyed();
            // �{�[�����폜
            Destroy(gameObject);
        }
    }
}
