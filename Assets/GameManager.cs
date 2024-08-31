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
        // ゲームを停止
        //Time.timeScale = 0;
        // Restartボタンを表示
        restartButton.SetActive(true);
    }

    // ゲーム再開
    public void Restart()
    {
        // シーンを再読み込み
        SceneManager.LoadScene("GameScene");
    }
}
