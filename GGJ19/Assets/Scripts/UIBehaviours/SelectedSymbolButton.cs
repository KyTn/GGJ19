using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectedSymbolButton : MonoBehaviour
{
    public SymbolId SymbolId;

    Image Image;
    

    void Awake()
    {
        Image = GetComponent<Image>();
    }

    void Start()
    {
        SetSymbol(SymbolId);
    }

    public void SetSymbol(SymbolId symbolId)
    {
        SymbolId = symbolId;
        Texture2D texture = SymbolManager.GetSymbolById(SymbolId);
        Image.sprite = Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );
    }

}
