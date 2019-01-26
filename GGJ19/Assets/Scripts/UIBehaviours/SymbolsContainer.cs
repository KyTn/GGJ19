using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rect.SetParent(SymbolsContainer_Container);
        rect.localScale = Vector3.one;
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);

        Symbols.Add(newSymbol);
    }
    
}
