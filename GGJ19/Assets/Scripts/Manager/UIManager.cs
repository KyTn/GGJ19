using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SymbolsContainer SymbolSelectablesContainer;
    public SymbolsSelectedContainer SymbolSelectedContainer;
    public RectTransform BottomPanel_Symbols;


    public static UIManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("UIManager already exists");
            return;
        }
        Instance = this;
    }

    void Start()
    {
        ResetUI();
    }

    public void ResetUI()
    {
        ShowOrHideBottomPanel_Symbols(true);
    }


    public void ShowOrHideBottomPanel_Symbols(bool insta = false)
    {
        switch (GameManager.Instance.InGameStates)
        {
            case InGameStates.InWorld:
                BottomPanel_Symbols.DOAnchorPosY(-500, insta ? 0.0001f : 0.8f); break;
            case InGameStates.InDialog:
                BottomPanel_Symbols.DOAnchorPosY(0, insta ? 0.0001f : 0.8f); break;
        }
    }


    public void AddSymbolToAnswer(SymbolId symbolId)
    {
        SymbolSelectedContainer.AddSymbol(symbolId);
    }

    public void RemoveLastSymbolOfAnswer()
    {
        SymbolSelectedContainer.RemoveLast();
    }
    public void SendAnswer()
    {

    }


    bool CanPressed_BButton = true;
    bool CanPressed_YButton = true;
    void Update()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            if (InputController.Instance.BButton == 0)
            {
                CanPressed_BButton = true;
            }

            if (CanPressed_BButton && InputController.Instance.BButton > 0)
            {
                RemoveLastSymbolOfAnswer();
                CanPressed_BButton = false;
            }

            if (InputController.Instance.YButton == 0)
            {
                CanPressed_YButton = true;
            }

            if (CanPressed_YButton && InputController.Instance.YButton > 0)
            {
                SendAnswer();
                CanPressed_BButton = false;
            }
        }
    }

}
