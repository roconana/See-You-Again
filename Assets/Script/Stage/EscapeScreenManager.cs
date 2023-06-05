using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeScreenManager : MonoBehaviour
{
    public GameObject escapeScreen;
    public Button resumeButton;
    public Button mainMenuButton;
    public Button quitButton;

    public Slider volumeSlider;

    private bool isPaused = false;

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitButton.onClick.AddListener(QuitGame);

        // 슬라이더의 초기 값을 현재 음량에 맞춥니다.
        volumeSlider.value = AudioListener.volume;

        // 슬라이더 값이 변경될 때 호출될 함수를 설정합니다.
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);

        // Hide the escape screen initially
        escapeScreen.SetActive(false);
    }

    private void Update()
    {
        // Check for the Esc key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between pausing/unpausing the game and showing/hiding the escape screen
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Stop the game time
        isPaused = true;
        escapeScreen.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game time
        isPaused = false;
        escapeScreen.SetActive(false);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    private void QuitGame()
    {
        // Add code to quit the game (for standalone builds) or stop the editor (in the Unity editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnVolumeSliderChanged(float value)
    {
        // 슬라이더 값에 따라 음량을 조절합니다.
        AudioListener.volume = value;
    }
}
