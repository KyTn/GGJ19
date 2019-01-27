using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SymbolsContainer SymbolSelectablesContainer;
    public SymbolsSelectedContainer SymbolSelectedContainer;
    public RectTransform BottomPanel_Symbols;
    public RectTransform OtherConversationSandwich;
    public RectTransform PlayerConversationSandwich;

    public Image AButton;

    public SymbolsSelectedContainer OtherSandwichSymbolContainer;

    public RectTransform MapPanel;


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
        ShowOrHideOtherConversationSandwich(true);
        ShowOrHidePlayerConversationSandwich(true);
    }


    public void ShowOrHideBottomPanel_Symbols(bool insta = false, bool? forceShow = null)
    {
        if (forceShow != null)
        {
            var value =  forceShow.Value ? 0 : -500;
            BottomPanel_Symbols.DOAnchorPosY(value, insta ? 0.0001f : 0.8f);
            return;
        }

        switch (GameManager.Instance.InGameStates)
        {
            case InGameStates.InWorld:
                BottomPanel_Symbols.DOAnchorPosY(-500, insta ? 0.0001f : 0.8f); break;
            case InGameStates.InDialog:
                BottomPanel_Symbols.DOAnchorPosY(0, insta ? 0.0001f : 0.8f); break;
        }



    }

    public void ShowOrHideOtherConversationSandwich(bool insta = false, bool? forceShow = null)
    {

        if (forceShow != null)
        {
            var value = forceShow.Value ? 0 : 800;
            OtherConversationSandwich.DOAnchorPosX(value, insta ? 0.0001f : 0.8f);
            return;
        }
        
        switch (GameManager.Instance.InGameStates)
        {
            case InGameStates.InWorld:
                OtherConversationSandwich.DOAnchorPosX(800, insta ? 0.0001f : 0.8f); break;
            case InGameStates.InDialog:
                OtherConversationSandwich.DOAnchorPosX(0, insta ? 0.0001f : 0.8f); break;
        }
    }

    public void ShowOrHidePlayerConversationSandwich(bool insta = false, bool? forceShow = null)
    {

        if (forceShow != null)
        {
            var value = forceShow.Value ? 0 : -800;
            PlayerConversationSandwich.DOAnchorPosX(value, insta ? 0.0001f : 0.8f);
            return;
        }

        switch (GameManager.Instance.InGameStates)
        {
            case InGameStates.InWorld:
                PlayerConversationSandwich.DOAnchorPosX(-800, insta ? 0.0001f : 0.8f); break;
            case InGameStates.InDialog:
                PlayerConversationSandwich.DOAnchorPosX(0, insta ? 0.0001f : 0.8f); break;
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

    public void AddSymbolToOther(SymbolId symbolId)
    {
        OtherSandwichSymbolContainer.AddSymbol(symbolId);
    }
    
    public void ShowOrHideMap(bool insta = false)
    {
        switch (GameManager.Instance.InGameStates)
        {
            case InGameStates.InWorld:
                MapPanel.DOAnchorPosY(1500, insta ? 0.0001f : 0.8f); break;

            case InGameStates.InMap:
                MapPanel.DOAnchorPosY(0, insta ? 0.0001f : 0.8f); break;
        }
    }

}
