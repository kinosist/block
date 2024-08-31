using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBlock : Block
{
    public GameObject ballPrefab; // 新しいボールのPrefab

    // 衝突判定をオーバーライド
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitPoints--; // 耐久力を減少させる

            // ヒット時に光る
            StartCoroutine(Glow());

            if (hitPoints <= 0)
            {
                // ブロックを破壊する前にボールを2つに増やす
                SplitBall(collision.gameObject);
                Destroy(this.gameObject); // 耐久力が0以下になったらブロックを破壊する
            }
        }
    }

    private void SplitBall(GameObject originalBall)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // 新しいボールを2つ生成
        for (int i = 0; i < 2; i++)
        {
            GameObject newBall = Instantiate(ballPrefab, originalBall.transform.position, Quaternion.identity);
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            // 新しいボールにランダムな方向と速度を与える
            rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized * originalBall.GetComponent<Ball>().speed;

            // ゲームマネージャーにボールが生成されたことを通知
            gameManager.BallCreated();
        }
    }
}