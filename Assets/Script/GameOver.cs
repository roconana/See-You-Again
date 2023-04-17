using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPopup;
    public Vector3 resetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gameover")
        {
            Time.timeScale = 0f; // ���� �Ͻ�����
            gameOverPopup.SetActive(true); // ���ӿ��� �˾� ���
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // ���� �簳
        gameOverPopup.SetActive(false); // ���ӿ��� �˾� ����
        // �ϴ��� ���� ��ǥ���� �÷��̾� ���� �����
        transform.position = resetPosition;
    }
}
