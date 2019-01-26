using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public int DialogID = -1;
    DialogObject CurrentDialog = null;

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

            CurrentDialog = DialogBank.GetDialogById(DialogID);
            ShowDialog();

        }
        else if(GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            ResolveDialog();
        }
        
    }

    public void ShowDialog()
    {
        foreach (var item in CurrentDialog.OtherSymbolsDialog)
        {
            UIManager.Instance.AddSymbolToOther(item);
        }
        StartCoroutine(RoutineCountDownBeforeResolving());
        
    }

    IEnumerator RoutineCountDownBeforeResolving()
    {
        yield return new WaitForSeconds(3f);
        if (CurrentDialog.DialogType == DialogType.InterDialogObject ||
            CurrentDialog.DialogType == DialogType.NoDialogObject)
        {
            // UIManager enable AButton press
            UIManager.Instance.AButton.gameObject.SetActive(true);
        }
        else if (CurrentDialog.DialogType == DialogType.DialogFinalObject)
        {
            // UIManager enable bottom
        }
    }


    public void ResolveDialog(List<SymbolId> playerResponse = null)
    {

    }


    public void EndDialog()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            PlayerController.instance.Stop = true;
            GameManager.Instance.ChangeToInWindow(() => PlayerController.instance.Stop = false);
        }

    }

    void Update()
    {
        if (CurrentDialog.DialogType == DialogType.NoDialogObject && InputController.Instance.AButton > 0)
        {
            // END DIALOG
        }
        if (CurrentDialog.DialogType == DialogType.DialogFinalObject)
        {
            // ???
        }
        if (CurrentDialog.DialogType == DialogType.InterDialogObject && InputController.Instance.AButton > 0)
        {
            // ???
        }
    }



}
