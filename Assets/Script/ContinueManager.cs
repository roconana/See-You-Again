using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    public GameObject fadeOutObject;
    public float fadeOutDuration = 3f;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;

    public void Start()
    {
        fadeOutObject.SetActive(false);

        button1.onClick.AddListener(LoadScene1);
        button2.onClick.AddListener(LoadScene2);
        button3.onClick.AddListener(LoadScene3);
        button4.onClick.AddListener(LoadScene4);
        button5.onClick.AddListener(LoadScene5);
        button6.onClick.AddListener(LoadScene6);
        button7.onClick.AddListener(LoadScene7);
        button8.onClick.AddListener(LoadScene8);
        button9.onClick.AddListener(LoadScene9);
        button10.onClick.AddListener(LoadScene10);
    }

    public void LoadScene1()
    {
        StartCoroutine(LoadSceneCoroutine("Stage1_1"));
    }
    public void LoadScene2()
    {
        StartCoroutine(LoadSceneCoroutine("Stage1_2"));
    }

    public void LoadScene3()
    {
        StartCoroutine(LoadSceneCoroutine("Stage1_3"));
    }

    public void LoadScene4()
    {
        StartCoroutine(LoadSceneCoroutine("Stage1_4"));
    }

    public void LoadScene5()
    {
        StartCoroutine(LoadSceneCoroutine("Stage1_5"));
    }

    public void LoadScene6()
    {
        StartCoroutine(LoadSceneCoroutine("Stage2_1"));
    }

    public void LoadScene7()
    {
        StartCoroutine(LoadSceneCoroutine("Stage2_2"));
    }

    public void LoadScene8()
    {
        StartCoroutine(LoadSceneCoroutine("Stage2_3"));
    }

    public void LoadScene9()
    {
        StartCoroutine(LoadSceneCoroutine("Stage2_4"));
    }

    public void LoadScene10()
    {
        StartCoroutine(LoadSceneCoroutine("Start"));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        fadeOutObject.SetActive(true);
        yield return new WaitForSeconds(fadeOutDuration);
        SceneManager.LoadScene(sceneName);
    }

}
