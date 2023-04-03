using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialog dialog;

    public void StartDialog()
    {
        print("start DIalog");

        dialog.StartDialog();
    }
}
