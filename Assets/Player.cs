using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;  // プレイヤーのスピード

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 4.0f)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }
        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -4.0f)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
    }
}
