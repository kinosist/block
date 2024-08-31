using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 3.0f;  // ボールのスピード
    private Rigidbody rb;       // Rigidbodyコンポーネント
    private GameObject gameManager; // GameManagerオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        // ボールに初速を与える
        rb.velocity = (transform.forward + transform.right) * speed;
        // GameManagerオブジェクトを取得
        gameManager = GameObject.Find("GameManager");
        // ゲームマネージャーにボールが生成されたことを通知
        gameManager.GetComponent<GameManager>().BallCreated();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 衝突判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gameover")
        {
            // ボールを削除する前にGameManagerに通知
            gameManager.GetComponent<GameManager>().BallDestroyed();
            // ボールを削除
            Destroy(gameObject);
        }
    }
}
