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
            textDialog.text = info.talk;

            info.onEndTalk.Invoke();

            yield return  StartCoroutine(StayByKeyDown());
            yield return  StartCoroutine(StayByKeyUp());
        }

        onEndEveryDialog.Invoke();
    }

    private IEnumerator StayByKeyDown() { 
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Z)) break; 

            yield return null;
        }
        print("DOWN");
    }
    
    private IEnumerator StayByKeyUp() { 
        while(true)
        {
            if(Input.GetKeyUp(KeyCode.Z)) break; 

            yield return null;
        }

        print("UP");
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
