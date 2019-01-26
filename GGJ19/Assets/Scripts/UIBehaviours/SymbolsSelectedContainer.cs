using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolsSelectedContainer : MonoBehaviour
{

    public GameObject SymbolButtonPrefab;
    public RectTransform SymbolsSelectedContainer_Container;

    List<GameObject> Symbols = new List<GameObject>();
    
    public void AddSymbol(SymbolId symbolId)
    {
        GameObject newSymbol = Instantiate(SymbolButtonPrefab) as GameObject;
        RectTransform rect = newSymbol.GetComponent<RectTransform>();
        rect.SetParent(SymbolsSelectedContainer_Container);
        rect.localScale = Vector3.one;
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);

        Symbols.Add(newSymbol);
    }

    public void RemoveLast()
    {
        int index = Symbols.Count - 1;
        if (index < 0) return;
        Destroy(Symbols[index]);
        Symbols.RemoveAt(index);
    }

    public void RemoveAll()
    {
        for (int i = 0; i < Symbols.Count; i++)
        {
            RemoveLast();
        }
    }
}
