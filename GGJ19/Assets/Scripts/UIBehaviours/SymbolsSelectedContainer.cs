using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SymbolsSelectedContainer : MonoBehaviour
{

    public GameObject SymbolButtonPrefab;
    public RectTransform SymbolsSelectedContainer_Container;

    List<SelectedSymbolButton> Symbols = new List<SelectedSymbolButton>();
    
    public void AddSymbol(SymbolId symbolId)
    {
        GameObject newSymbol = Instantiate(SymbolButtonPrefab) as GameObject;
        RectTransform rect = newSymbol.GetComponent<RectTransform>();
        rect.SetParent(SymbolsSelectedContainer_Container);
        rect.localScale = Vector3.one;
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);


        SelectedSymbolButton symbolButton = newSymbol.GetComponent<SelectedSymbolButton>();
        symbolButton.SymbolId = symbolId;

        Symbols.Add(symbolButton);

    }

    public void RemoveLast()
    {
        int index = Symbols.Count - 1;
        if (index < 0) return;
        Destroy(Symbols[index].gameObject);
        Symbols.RemoveAt(index);
    }

    public void RemoveAll()
    {
        for (int i = 0; i < Symbols.Count; i++)
        {
            RemoveLast();
        }
    }

    public List<SymbolId> GetResponse()
    {
        return Symbols.Select(x => x.SymbolId).ToList();
    }
}
