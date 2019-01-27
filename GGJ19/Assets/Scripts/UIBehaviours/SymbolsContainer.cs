using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SymbolsContainer : MonoBehaviour
{
    public GameObject SymbolButtonPrefab;
    public RectTransform SymbolsContainer_Container;

    List<GameObject> Symbols = new List<GameObject>();


    void Start()
    {
        AddSymbol(SymbolId.FireSymbol);
        AddSymbol(SymbolId.HeroSymbol);
    }

    public void AddSymbol(SymbolId symbolId)
    {
        GameObject newSymbol = Instantiate(SymbolButtonPrefab) as GameObject;
        RectTransform rect = newSymbol.GetComponent<RectTransform>();
        SymbolButton symbolButton = newSymbol.GetComponent<SymbolButton>();
        Button button = newSymbol.GetComponent<Button>();
        rect.SetParent(SymbolsContainer_Container);
        rect.localScale = Vector3.one;
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);

        Symbols.Add(newSymbol);

        symbolButton.SymbolId = symbolId;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            SymbolButton symbolButton2 = newSymbol.GetComponent<SymbolButton>();
            UIManager.Instance.SymbolSelectedContainer.AddSymbol(symbolButton2.SymbolId);
        });
    }

    public void FocusOnFirst()
    {
        EventSystem.current.SetSelectedGameObject(Symbols[0]);
    }


}
