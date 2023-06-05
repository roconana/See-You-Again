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
            Time.timeScale = 0f; // 게임 일시정지
            gameOverPopup.SetActive(true); // 게임오버 팝업 출력
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
        Time.timeScale = 1f; // 게임 재개
        gameOverPopup.SetActive(false); // 게임오버 팝업 숨김
        // 일단은 지정 좌표에서 플레이어 게임 재시작
        transform.position = resetPosition;
    }
}
