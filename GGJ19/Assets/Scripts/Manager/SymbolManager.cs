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
    FurySymbol,
    NiceResponseSymbol,
    BadResponseSymbol,

    //2nd village
    VillageSymbol,
    Food2Symbol,
    //TODO
    MoreFoodSymbol,
    FatherSymbol,
    TravelerSymbol,
    FarmerSymbol,
    FamilySymbol,
    DaySymbol,
    NightSymbol,

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
    public Texture2D FurySymbol;
    public Texture2D NiceResponseSymbol;
    public Texture2D BadResponseSymbol;

    //2nd village
    public Texture2D VillageSymbol;
    public Texture2D Food2Symbol;
    public Texture2D MoreFoodSymbol;
    public Texture2D FatherSymbol;
    public Texture2D TravelerSymbol;
    public Texture2D FarmerSymbol;
    public Texture2D FamilySymbol;
    public Texture2D DaySymbol;
    public Texture2D NightSymbol;

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

            case SymbolId.FurySymbol:
                ret = SymbolManager.Instance.FurySymbol; break;

            case SymbolId.NiceResponseSymbol:
                ret = SymbolManager.Instance.NiceResponseSymbol; break;

            case SymbolId.BadResponseSymbol:
                ret = SymbolManager.Instance.BadResponseSymbol; break;

            // 2nd ---------

            case SymbolId.VillageSymbol:
                ret = SymbolManager.Instance.VillageSymbol; break;

            case SymbolId.Food2Symbol:
                ret = SymbolManager.Instance.Food2Symbol; break;

            case SymbolId.MoreFoodSymbol:
                ret = SymbolManager.Instance.MoreFoodSymbol; break;

            case SymbolId.FatherSymbol:
                ret = SymbolManager.Instance.FatherSymbol; break;

            case SymbolId.TravelerSymbol:
                ret = SymbolManager.Instance.TravelerSymbol; break;

            case SymbolId.FarmerSymbol:
                ret = SymbolManager.Instance.FarmerSymbol; break;

            case SymbolId.FamilySymbol:
                ret = SymbolManager.Instance.FamilySymbol; break;

            case SymbolId.DaySymbol:
                ret = SymbolManager.Instance.DaySymbol; break;

            case SymbolId.NightSymbol:
                ret = SymbolManager.Instance.NightSymbol; break;

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