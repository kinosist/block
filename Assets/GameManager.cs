using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ブロックを入れるための配列
    public GameObject[] blocks;
    private GameObject text;
    private GameObject restartButton;
    private int ballCount; // 現在のボールの数

    // Start is called before the first frame update
    void Start()
    {
        // ブロックを全て取得
        blocks = GameObject.FindGameObjectsWithTag("Block");
        // テキストを取得
        text = GameObject.Find("Text");
        // Restartボタンを取得
        restartButton = GameObject.Find("RestartButton");
        // Restartボタンを非表示
        restartButton.SetActive(false);
        // 初期ボールの数をカウント
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // ブロック配列を更新
        blocks = GameObject.FindGameObjectsWithTag("Block");

        // ブロックが全てなくなったら
        if (blocks.Length == 0)
        {
            // ゲームクリア
            Debug.Log("Game Clear!");
            // テキストにゲームクリアを表示
            text.GetComponent<Text>().text = "Game Clear!";
            // ゲームを停止
            Time.timeScale = 0;
        }
    }

    // ゲームオーバー
    public void GameOver()
    {
        // ゲームオーバー
        Debug.Log("Game Over!");
        // テキストにゲームオーバーを表示
        text.GetComponent<Text>().text = "Game Over!";
        // Restartボタンを表示
        restartButton.SetActive(true);
    }

    // ボールが破壊されたときに呼び出す
    public void BallDestroyed()
    {
        ballCount--; // ボールの数を減少させる
        if (ballCount <= 0)
        {
            GameOver(); // ボールがすべてなくなったらゲームオーバー
        }
    }

    // ボールが生成されたときに呼び出す
    public void BallCreated()
    {
        ballCount++; // ボールの数を増加させる
    }

    // ゲーム再開
    public void Restart()
    {
        // シーンを再読み込み
        SceneManager.LoadScene("GameScene");
    }
}
