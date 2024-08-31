using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �u���b�N�����邽�߂̔z��
    public GameObject[] blocks;
    private GameObject text;
    private GameObject restartButton;
    private int ballCount; // ���݂̃{�[���̐�

    // Start is called before the first frame update
    void Start()
    {
        // �u���b�N��S�Ď擾
        blocks = GameObject.FindGameObjectsWithTag("Block");
        // �e�L�X�g���擾
        text = GameObject.Find("Text");
        // Restart�{�^�����擾
        restartButton = GameObject.Find("RestartButton");
        // Restart�{�^�����\��
        restartButton.SetActive(false);
        // �����{�[���̐����J�E���g
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // �u���b�N�z����X�V
        blocks = GameObject.FindGameObjectsWithTag("Block");

        // �u���b�N���S�ĂȂ��Ȃ�����
        if (blocks.Length == 0)
        {
            // �Q�[���N���A
            Debug.Log("Game Clear!");
            // �e�L�X�g�ɃQ�[���N���A��\��
            text.GetComponent<Text>().text = "Game Clear!";
            // �Q�[�����~
            Time.timeScale = 0;
        }
    }

    // �Q�[���I�[�o�[
    public void GameOver()
    {
        // �Q�[���I�[�o�[
        Debug.Log("Game Over!");
        // �e�L�X�g�ɃQ�[���I�[�o�[��\��
        text.GetComponent<Text>().text = "Game Over!";
        // Restart�{�^����\��
        restartButton.SetActive(true);
    }

    // �{�[�����j�󂳂ꂽ�Ƃ��ɌĂяo��
    public void BallDestroyed()
    {
        ballCount--; // �{�[���̐�������������
        if (ballCount <= 0)
        {
            GameOver(); // �{�[�������ׂĂȂ��Ȃ�����Q�[���I�[�o�[
        }
    }

    // �{�[�����������ꂽ�Ƃ��ɌĂяo��
    public void BallCreated()
    {
        ballCount++; // �{�[���̐��𑝉�������
    }

    // �Q�[���ĊJ
    public void Restart()
    {
        // �V�[�����ēǂݍ���
        SceneManager.LoadScene("GameScene");
    }
}
