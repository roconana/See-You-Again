using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour
{
    public GameObject fadeUI;
    public float transitionDelay = 2f;

    private bool isTransitioning = false;

    private void Start()
    {
        fadeUI.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        if (isTransitioning)
            return;

        StartCoroutine(TransitionToScene(sceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex)
    {
        isTransitioning = true;

        fadeUI.SetActive(true);
        yield return new WaitForSeconds(transitionDelay);

        SceneManager.LoadScene(sceneIndex);
    }
}
