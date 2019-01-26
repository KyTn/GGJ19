using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InGameStates
{
    InWorld = 0,
    InDialog = 1
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InGameStates InGameStates;

    [HideInInspector]
    public List<SymbolId> SymbolsUnlocked;
    public List<SymbolId> SymbolsInitials;

    public List<SymbolId> SymbolsSelected;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("GameManager already exists");
            return;
        }
        Instance = this;

    }

    private void Start()
    {
        InGameStates = InGameStates.InWorld;
        SymbolsUnlocked.AddRange(SymbolsInitials);

    }

    public void ChangeToInDialog(Action callbackWhenCompleteTween)
    {
        InGameStates = InGameStates.InDialog;
        CameraManager.Instance.Camera.transform.DOLocalRotateQuaternion(
            CameraManager.Instance.InDialogLocalPosition.localRotation, 0.8f);

        CameraManager.Instance.Camera.transform.DOMove(
            CameraManager.Instance.InDialogLocalPosition.position, 0.8f)
            .OnComplete(() => callbackWhenCompleteTween?.Invoke());


        UIManager.Instance.ShowOrHideBottomPanel_Symbols();
    }

    public void ChangeToInWindow(Action callbackWhenCompleteTween)
    {
        InGameStates = InGameStates.InWorld;
        CameraManager.Instance.Camera.transform.DOLocalRotateQuaternion(
            CameraManager.Instance.InWorldLocalPosition.localRotation, 0.8f);

        CameraManager.Instance.Camera.transform.DOMove(
            CameraManager.Instance.InWorldLocalPosition.position, 0.8f)
            .OnComplete(() => callbackWhenCompleteTween?.Invoke());


        UIManager.Instance.ShowOrHideBottomPanel_Symbols();
    }


    public void UnlockSymbol(SymbolId symbolId)
    {
        SymbolsUnlocked.Add(symbolId);
        UIManager.Instance.SymbolSelectablesContainer.AddSymbol(symbolId);
    }


}
