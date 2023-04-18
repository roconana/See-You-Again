using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Dialog : MonoBehaviour
{
    bool isTalking = false;

    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDialog;

    public List<DialogInfo> dialogInfos = new List<DialogInfo>();

    public UnityEvent onEndEveryDialog;
    public UnityEvent onEndDialogsAndSwitchScene;

    public GameObject player;
    public string nextScene;


    // The delay between each character in the typing effect.
    public float typingDelay = 0.05f;

    public void StartDialog()
    {
        if (isTalking) return;

        isTalking = true;
        this.gameObject.SetActive(true);

        StartCoroutine(DialogRoutine());
    }

    private IEnumerator DialogRoutine()
    {
        foreach (DialogInfo info in dialogInfos)
        {
            info.onStartTalk.Invoke();

            textName.text = info.name;

            // Clear the text dialog first.
            textDialog.text = "";

            // Iterate through each character in the dialogue text and add it to the TextMeshProUGUI component one by one.
            for (int i = 0; i < info.talk.Length; i++)
            {
                // Add the current character to the TextMeshProUGUI component.
                textDialog.text += info.talk[i];

                // Wait for a short delay before adding the next character to create the typing effect.
                yield return new WaitForSeconds(typingDelay);
            }

            info.onEndTalk.Invoke();

            yield return StartCoroutine(StayByKeyDown());
            yield return StartCoroutine(StayByKeyUp());
        }

        onEndEveryDialog.Invoke();
        onEndDialogsAndSwitchScene.Invoke();
    }

    private IEnumerator StayByKeyDown()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Z)) break;

            yield return null;
        }
        print("DOWN");
    }

    private IEnumerator StayByKeyUp()
    {
        while (true)
        {
            if (Input.GetKeyUp(KeyCode.Z)) break;

            yield return null;
        }

        print("UP");
    }

    public void MoveOn()
    {
        player.GetComponent<PlayerController>().isDontMove = true;
    }

    public void MoveOff()
    {
        player.GetComponent<PlayerController>().isDontMove = false;
    }

    [System.Serializable]
    public class DialogInfo
    {
        public string name;
        public string talk;
        public UnityEvent onStartTalk;
        public UnityEvent onEndTalk;
    }

}
