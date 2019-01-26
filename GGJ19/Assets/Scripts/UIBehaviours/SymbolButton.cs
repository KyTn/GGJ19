using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class SymbolButton : MonoBehaviour
{
    public SymbolId SymbolId;

    Button button;


    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        SetSymbol(SymbolId);
    }

    public void SetSymbol(SymbolId symbolId)
    {
        SymbolId = symbolId;
        Texture2D texture = SymbolManager.GetSymbolById(SymbolId);
        button.image.sprite = Sprite.Create(
            texture, 
            new Rect(0, 0, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f)
        );
    }

}
