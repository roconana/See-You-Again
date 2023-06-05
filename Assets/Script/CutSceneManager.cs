using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    [TextArea]
    public string talk;
    [TextArea]
    public string talk2;
    [TextArea]
    public string talk3;
    [TextArea]
    public string talk4;
    [TextArea]
    public string talk5;

    public GameObject scene_2;
    public GameObject scene_3;
    public GameObject scene_4;
    public GameObject dialogImage;
    public float typingDelay;
    private void StartTyping()
    {
        StartCoroutine(Typing());
    }

    private IEnumerator Typing()
    {
        textDialog.text = "";

        dialogImage.SetActive(true);

        for (int i = 0; i < talk.Length; i++)
        {
            // Add the current character to the TextMeshProUGUI component.
            textDialog.text += talk[i];

            yield return new WaitForSeconds(typingDelay);
        }

        yield return new WaitForSeconds(0.75f);

        textDialog.text = "";
        for (int i = 0; i < talk2.Length; i++)
        {
            textDialog.text += talk2[i];

            yield return new WaitForSeconds(typingDelay);
        }
        yield return new WaitForSeconds(0.75f);
        textDialog.text = "";
        for (int i = 0; i < talk3.Length; i++)
        {
            textDialog.text += talk3[i];

            yield return new WaitForSeconds(typingDelay);
        }
        yield return new WaitForSeconds(0.75f);
        textDialog.text = "";
        NextImage(scene_2);
    }

    private void NextImage(GameObject scene)
    {
        scene.SetActive(true);
    }

    private void Talk_4()
    {
        StartCoroutine(Talk_4_typing());
    }

    private IEnumerator Talk_4_typing()
    {
        textDialog.text = "";

        for (int i = 0; i < talk4.Length; i++)
        {
            // Add the current character to the TextMeshProUGUI component.
            textDialog.text += talk4[i];

            yield return new WaitForSeconds(typingDelay);
        }
        yield return new WaitForSeconds(0.75f);
        textDialog.text = "";
        NextImage(scene_3);
        Talk_5();
    }

    private void Talk_5()
    {
        StartCoroutine(Talk_5_typing());
    }

    private IEnumerator Talk_5_typing()
    {
        yield return new WaitForSeconds(0.75f);
        textDialog.text = "";

        for (int i = 0; i < talk5.Length; i++)
        {
            // Add the current character to the TextMeshProUGUI component.
            textDialog.text += talk5[i];

            yield return new WaitForSeconds(typingDelay);
        }

        yield return new WaitForSeconds(1f);
        textDialog.text = "";
        scene_4.SetActive(true);
        GameObject.Find("dialogImage").SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Stage1_1");
    }
}