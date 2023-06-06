using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCutSceneManager : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    [TextArea]
    public string talk;
    [TextArea]
    public string talk2;

    public GameObject scene_2;
    public GameObject scene_3;
    public GameObject dialogImage;
    public float typingDelay;
    private void StartTyping()
    {
        StartCoroutine(Typing());
    }

    private IEnumerator Typing()
    {
        dialogImage.SetActive(true);

        for (int i = 0; i < talk.Length; i++)
        {
            textDialog.text += talk[i];

            yield return new WaitForSeconds(typingDelay);
        }

        yield return new WaitForSeconds(0.75f);

        textDialog.text = ""; // 대화창 빈칸으로 만들어주는 용도

        for (int i = 0; i < talk2.Length; i++)
        {
            textDialog.text += talk2[i];

            yield return new WaitForSeconds(typingDelay);
        }

        yield return new WaitForSeconds(0.75f);
        textDialog.text = ""; // 대화창 빈칸으로 만들어주는 용도
        GameObject.Find("dialogImage").SetActive(false);

        yield return new WaitForSeconds(2.5f);
        NextImage(scene_2);
        yield return new WaitForSeconds(5f);
        NextImage(scene_3);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Start");
    }

    private void NextImage(GameObject scene)
    {
        scene.SetActive(true);
    }

}
