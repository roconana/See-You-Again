using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSceneSwitch : MonoBehaviour
{
    public string nextScene; // The name of the scene you want to load after the splash screen
    public float delayTime = 2.0f; // The delay time before switching to the next scene
    public GameObject fadeOutImage; // The fade out UI image

    private bool canSwitchScene = false; // A flag to prevent switching scenes multiple times

    void Update()
    {
        if (Input.anyKeyDown && !canSwitchScene)
        {
            canSwitchScene = true; // Set the flag to prevent switching scenes multiple times

            // Turn on the fadeout sprite
            fadeOutImage.SetActive(true);

            // Call the SwitchScene function after a delay time
            Invoke("SwitchScene", delayTime);
        }
    }

    // Switches to the next scene
    private void SwitchScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
