using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;  // �v���C���[�̃X�s�[�h

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �E�ړ�
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 4.0f)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }
        // ���ړ�
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -4.0f)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }
}
