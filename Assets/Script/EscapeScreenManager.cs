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

    private bool isPaused = false;

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitButton.onClick.AddListener(QuitGame);

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
}
