using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartDialog : MonoBehaviour
{

    public int DialogID = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Can Start conversation
            DialogManager.Instance.DialogID = DialogID;
            DialogManager.Instance.FirstDialogID = DialogID;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Cannot Start conversation
            DialogManager.Instance.DialogID = -1;
            DialogManager.Instance.FirstDialogID = -1;
        }
    }
}
