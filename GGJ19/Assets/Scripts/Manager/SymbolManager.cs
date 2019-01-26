using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SymbolId
{ 
    AnonymousSymbol,
    HeroSymbol,
    FireSymbol,
    LeaderSymbol,
    AskingSymbol,
    HelpSymbol,
    FoodSymbol,
    BlacksmithSymbol,
    FishermanSymbol,
    StealSymbol,

    //2nd village
    VillageSymbol,
    Food2Symbol,

    // 3rd village
    DeadmanSymbol,
    DogSymbol,
    GrandmatherSymbol,
    KidSymbol,
    HunterSymbol
}

public class SymbolManager : MonoBehaviour
{
    public static SymbolManager Instance;

    public Texture2D NotFoundSymbol;
    
    public Texture2D AnonymousSymbol;
    public Texture2D HeroSymbol;
    public Texture2D FireSymbol;
    public Texture2D LeaderSymbol;
    public Texture2D AskingSymbol;
    public Texture2D HelpSymbol;
    public Texture2D FoodSymbol;
    public Texture2D BlacksmithSymbol;
    public Texture2D FishermanSymbol;
    public Texture2D StealSymbol;

    //2nd village
    public Texture2D VillageSymbol;
    public Texture2D Food2Symbol;

    // 3rd village
    public Texture2D DeadmanSymbol;
    public Texture2D DogSymbol;
    public Texture2D GrandmatherSymbol;
    public Texture2D KidSymbol;
    public Texture2D HunterSymbol;


    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("SymbolManager already exists");
            return;
        }
        Instance = this;
    }

    public static Texture2D GetSymbolById(SymbolId symbolId)
    {
        Texture2D ret = null;
        switch (symbolId)
        {
            case SymbolId.AnonymousSymbol:
                ret = SymbolManager.Instance.AnonymousSymbol; break;

            case SymbolId.HeroSymbol:
                ret = SymbolManager.Instance.HeroSymbol; break;

            case SymbolId.FireSymbol:
                ret = SymbolManager.Instance.FireSymbol; break;

            case SymbolId.LeaderSymbol:
                ret = SymbolManager.Instance.LeaderSymbol; break;

            case SymbolId.AskingSymbol:
                ret = SymbolManager.Instance.AskingSymbol; break;

            case SymbolId.HelpSymbol:
                ret = SymbolManager.Instance.HelpSymbol; break;

            case SymbolId.FoodSymbol:
                ret = SymbolManager.Instance.FoodSymbol; break;

            case SymbolId.BlacksmithSymbol:
                ret = SymbolManager.Instance.BlacksmithSymbol; break;

            case SymbolId.FishermanSymbol:
                ret = SymbolManager.Instance.FishermanSymbol; break;

            case SymbolId.StealSymbol:
                ret = SymbolManager.Instance.StealSymbol; break;

            // 2nd ---------

            case SymbolId.VillageSymbol:
                ret = SymbolManager.Instance.VillageSymbol; break;

            case SymbolId.Food2Symbol:
                ret = SymbolManager.Instance.Food2Symbol; break;

            // 3nd ---------
            case SymbolId.DeadmanSymbol:
                ret = SymbolManager.Instance.DeadmanSymbol; break;

            case SymbolId.DogSymbol:
                ret = SymbolManager.Instance.DogSymbol; break;

            case SymbolId.GrandmatherSymbol:
                ret = SymbolManager.Instance.GrandmatherSymbol; break;

            case SymbolId.KidSymbol:
                ret = SymbolManager.Instance.KidSymbol; break;

            case SymbolId.HunterSymbol:
                ret = SymbolManager.Instance.HunterSymbol; break;
        }

        return ret != null? ret: SymbolManager.Instance.NotFoundSymbol;

    }
}