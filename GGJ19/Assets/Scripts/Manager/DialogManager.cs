using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public int DialogID = -1;
    public int FirstDialogID = -1;
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


        UIManager.Instance.AButton.gameObject.SetActive(false);
        UIManager.Instance.ShowOrHideBottomPanel_Symbols();
        UIManager.Instance.ShowOrHidePlayerConversationSandwich();
        UIManager.Instance.ShowOrHideOtherConversationSandwich();

        UIManager.Instance.SymbolSelectedContainer.RemoveAll();
        UIManager.Instance.OtherSandwichSymbolContainer.RemoveAll();

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
            CurrentDialog = DialogBank.GetDialogById(DialogID);
            ShowDialog();
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
        if (CurrentDialog.DialogType == DialogType.NoDialogObject)
        {
            UIManager.Instance.ShowOrHideBottomPanel_Symbols(forceShow: false);
            UIManager.Instance.ShowOrHidePlayerConversationSandwich(forceShow: false);

            yield return new WaitForSeconds(0.8f);

            // UIManager enable AButton press
            UIManager.Instance.AButton.gameObject.SetActive(true);

            waitingResponse = true;
        }
        else if (CurrentDialog.DialogType == DialogType.InterDialogObject)
        {
            yield return new WaitForSeconds(0.8f);

            // UIManager enable bottom
            UIManager.Instance.ShowOrHideBottomPanel_Symbols();
            UIManager.Instance.ShowOrHidePlayerConversationSandwich();
            UIManager.Instance.SymbolSelectablesContainer.FocusOnFirst();
            waitingResponse = true;
        }
    }
    private void LearnSymbols(List<SymbolId> symbols)
    {
        if (symbols == null) return;

        GameManager.Instance.SymbolsUnlocked.AddRange(symbols);
        GameManager.Instance.SymbolsUnlocked = GameManager.Instance.SymbolsUnlocked.Distinct().ToList();

        symbols.ForEach(x => UIManager.Instance.SymbolSelectablesContainer.AddSymbol(x));
    }

    public void ResolveDialog(List<SymbolId> playerResponse = null)
    {
        LearnSymbols(CurrentDialog.UnlockSymbols);

        waitingResponse = false;
        UIManager.Instance.AButton.gameObject.SetActive(false);

        if (CurrentDialog == null) return;
        try
        {
            if (CurrentDialog.DialogType == DialogType.NoDialogObject)
            {
                var dialog = CurrentDialog as NoDialogObject;


                if (dialog.OtherDialog.HasValue)
                {
                    DialogID = dialog.OtherDialog.Value;
                    StartDialog();
                    return;
                }
                else
                {
                    EndDialog();
                }
            }
            else if (CurrentDialog.DialogType == DialogType.InterDialogObject)
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
                    else
                    {
                        EndDialog();
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
                    else
                    {
                        EndDialog();
                    }
                }
            }
        }
        catch (Exception e)
        {

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
                if (dialog.PlayerSymbolsNiceDialog[0] != playerResponse[0])
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
            UIManager.Instance.ShowOrHideOtherConversationSandwich();

            UIManager.Instance.SymbolSelectedContainer.RemoveAll();
            UIManager.Instance.OtherSandwichSymbolContainer.RemoveAll();
        }
        CurrentDialog = null;
        DialogID = FirstDialogID;
    }


    bool CanPress = true;
    bool waitingResponse = false;

    private void Update()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog && CurrentDialog != null)
        {
            if (!waitingResponse) return;

            if (CurrentDialog != null && CurrentDialog.DialogType == DialogType.NoDialogObject)
            {
                if (InputController.Instance.AButton > 0)
                {
                    ResolveDialog();
                }
            }


            if (InputController.Instance.AButton == 0 &&
                InputController.Instance.BButton == 0 &&
                InputController.Instance.XButton == 0 &&
                InputController.Instance.YButton == 0)
            {
                CanPress = true;
            }
            if (!CanPress) return;

            if (CurrentDialog != null && CurrentDialog.DialogType == DialogType.InterDialogObject)
            {
                if (InputController.Instance.YButton > 0)
                {
                    CanPress = false;
                    var response = UIManager.Instance.SymbolSelectedContainer.GetResponse();
                    ResolveDialog(response);
                }
                else if (InputController.Instance.BButton > 0)
                {
                    CanPress = false;
                    UIManager.Instance.SymbolSelectedContainer.RemoveLast();
                }
                else if (InputController.Instance.XButton > 0)
                {
                    CanPress = false;
                    EndDialog();
                }
            }
        }

    }




}
