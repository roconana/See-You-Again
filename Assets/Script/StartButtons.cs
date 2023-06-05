using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtons : MonoBehaviour
{
    public Button startButton;
    public Button continueButton;
    public Button quitButton;
    public GameObject fadeOutObject;
    public float fadeOutDuration = 2f;

    private void Start()
    {
        fadeOutObject.SetActive(false);

        startButton.onClick.AddListener(StartGame);
        continueButton.onClick.AddListener(ContinueGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        fadeOutObject.SetActive(true);

        yield return new WaitForSeconds(fadeOutDuration);

        SceneManager.LoadScene("IntroCS");
    }

    public void ContinueGame()
    {
        StartCoroutine(ContinueGameCoroutine());
    }

    private IEnumerator ContinueGameCoroutine()
    {
        fadeOutObject.SetActive(true);

        yield return new WaitForSeconds(fadeOutDuration);

        SceneManager.LoadScene("Continue");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
