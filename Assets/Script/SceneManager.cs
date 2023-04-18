using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public string initialSceneName; // Name of the scene to load on game start
    public string restartSceneName; // Name of the scene to load on game restart
    public float fadeDuration; // Duration of fade in/out effect

    private bool isFading;
    private Image fadeImage;
    private AsyncOperation loadSceneOperation;
    private Vector3 playerPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        fadeImage = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        LoadInitialScene();
    }

    private void LoadInitialScene()
    {
        playerPosition = Vector3.zero; // Set default player position

        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("lastSceneName")))
        {
            initialSceneName = PlayerPrefs.GetString("lastSceneName");
            playerPosition.x = PlayerPrefs.GetFloat("lastPlayerPosX");
            playerPosition.y = PlayerPrefs.GetFloat("lastPlayerPosY");
            playerPosition.z = PlayerPrefs.GetFloat("lastPlayerPosZ");
        }

        LoadScene(initialSceneName);
    }

    public void LoadScene(string sceneName)
    {
        if (isFading)
        {
            return;
        }

        StartCoroutine(FadeScene(sceneName));
    }

    private IEnumerator FadeScene(string sceneName)
    {
        isFading = true;

        if (loadSceneOperation != null)
        {
            loadSceneOperation.allowSceneActivation = false;
        }

        fadeImage.gameObject.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1.0f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);

        if (loadSceneOperation == null)
        {
            loadSceneOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            loadSceneOperation.allowSceneActivation = false;
        }

        PlayerPrefs.SetString("lastSceneName", sceneName);

        if (sceneName == restartSceneName)
        {
            playerPosition = Vector3.zero; // Reset player position
        }
        else
        {
            PlayerPrefs.SetFloat("lastPlayerPosX", playerPosition.x);
            PlayerPrefs.SetFloat("lastPlayerPosY", playerPosition.y);
            PlayerPrefs.SetFloat("lastPlayerPosZ", playerPosition.z);
        }

        loadSceneOperation.allowSceneActivation = true;

        yield return new WaitUntil(() => loadSceneOperation.isDone);

        fadeImage.CrossFadeAlpha(0.0f, fadeDuration, false);

        yield return new WaitForSeconds(fadeDuration);

        fadeImage.gameObject.SetActive(false);

        isFading = false;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }
}
