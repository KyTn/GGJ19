using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public int DialogID = -1;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("DialogManager already exists");
            return;
        }
        Instance = this;

    }


    public void StartDialog()
    {
        if(DialogID == -1)
        {
            return;
        }

        if (GameManager.Instance.InGameStates == InGameStates.InWorld)
        {
            PlayerController.instance.Stop = true;
            GameManager.Instance.ChangeToInDialog(() => PlayerController.instance.Stop = false);
            UIManager.Instance.ShowOrHideOtherConversationSandwich();

            DialogBank.GetDialogById(DialogID);

            //UIManager.Instance.AddSymbolToOther()

        }
        
    }

    public void EndDialog()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            PlayerController.instance.Stop = true;
            GameManager.Instance.ChangeToInWindow(() => PlayerController.instance.Stop = false);
        }

    }


}
