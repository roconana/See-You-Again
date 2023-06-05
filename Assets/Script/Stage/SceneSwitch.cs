using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        StartCoroutine(StaySceneChange(sceneName));
    }

    private IEnumerator StaySceneChange(string sceneName)
    {
        yield return new WaitForSeconds(2.01f);
        SceneManager.LoadScene(sceneName);
    }
}