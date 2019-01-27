using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (DialogID == -1)
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
        else if (GameManager.Instance.InGameStates == InGameStates.InDialog)
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
        if (CurrentDialog.DialogType == DialogType.NoDialogObject)
        {
            // UIManager enable AButton press
            UIManager.Instance.AButton.gameObject.SetActive(true);
        }
        else if (CurrentDialog.DialogType == DialogType.InterDialogObject)
        {
            // UIManager enable bottom
            UIManager.Instance.ShowOrHideBottomPanel_Symbols();
            UIManager.Instance.ShowOrHidePlayerConversationSandwich();
            UIManager.Instance.SymbolSelectablesContainer.FocusOnFirst();
        }
    }


    public void ResolveDialog(List<SymbolId> playerResponse = null)
    {
        UIManager.Instance.AButton.gameObject.SetActive(false);

        if (CurrentDialog.DialogType == DialogType.NoDialogObject)
        {
            var dialog = CurrentDialog as NoDialogObject;
            if (dialog.OtherDialog.HasValue)
            {
                DialogID = dialog.OtherDialog.Value;
                StartDialog();
                return;
            }
        }


        if (CurrentDialog.DialogType == DialogType.InterDialogObject)
        {
            var dialog = CurrentDialog as InterDialogObject;
            if (playerResponse != null && 
                dialog.PlayerSymbolsNiceDialog.Any() && 
                CheckNiceResponse(dialog, playerResponse))
            {
                if (dialog.OtherDialogNiceResponse.HasValue)
                {
                    DialogID = dialog.OtherDialogNiceResponse.Value;
                    StartDialog();
                    return;
                }
            }
            else
            {
                if (dialog.OtherDialogBadResponse.HasValue)
                {
                    DialogID = dialog.OtherDialogBadResponse.Value;
                    StartDialog();
                    return;
                }
            }
            
        }
    }

    private bool CheckNiceResponse(InterDialogObject dialog, List<SymbolId> playerResponse)
    {
        bool isNiceResponse = false;
        if (dialog.PlayerSymbolsNiceDialog.Count == playerResponse.Count)
        {
            isNiceResponse = true;
            for (int i = 0; i < playerResponse.Count; i++)
            {
                if (dialog.PlayerSymbolsNiceDialog[0] == playerResponse[0])
                {
                    isNiceResponse = false;
                    break;
                }
            }
        }
        return isNiceResponse;
    }



    public void EndDialog()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            PlayerController.instance.Stop = true;
            GameManager.Instance.ChangeToInWindow(() => PlayerController.instance.Stop = false);
            
            UIManager.Instance.AButton.gameObject.SetActive(false);
            UIManager.Instance.ShowOrHideBottomPanel_Symbols();
            UIManager.Instance.ShowOrHidePlayerConversationSandwich();
        }

    }


    private void Update()
    {
        if(GameManager.Instance.InGameStates == InGameStates.InDialog &&
            CurrentDialog != null)
        {
            if(CurrentDialog.DialogType == DialogType.InterDialogObject)
            {

            }
        }
        
    }




}
