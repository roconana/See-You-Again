using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LongSceneSwitch : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        StartCoroutine(StaySceneChange(sceneName));
    }

    private IEnumerator StaySceneChange(string sceneName)
    {
        yield return new WaitForSeconds(10.5f);
        SceneManager.LoadScene(sceneName);
    }
}