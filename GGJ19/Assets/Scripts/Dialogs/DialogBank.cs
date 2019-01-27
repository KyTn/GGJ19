using System.Collections.Generic;

public class DialogBank
{

    private static Dictionary<int, DialogObject> DialogsById = new Dictionary<int, DialogObject>();

    static DialogBank()
    {
        /*****************[LEADER 1 {1-19}]**********************/
        DialogsById.Add(1, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 3,
            OtherDialogBadResponse = 2
        });

        DialogsById.Add(2, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol }
        });

        DialogsById.Add(3, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 5,
            OtherDialogBadResponse = 4
        });

        DialogsById.Add(4, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol, SymbolId.AskingSymbol, SymbolId.AskingSymbol }
        });

        DialogsById.Add(5, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.HeroSymbol, SymbolId.HelpSymbol, SymbolId.LeaderSymbol }
        });

        DialogsById.Add(6, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AnonymousSymbol, SymbolId.StealSymbol, SymbolId.FoodSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.BlacksmithSymbol },
            OtherDialogNiceResponse = 7,
            OtherDialogBadResponse = 6
        });

        DialogsById.Add(7, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.BadResponseSymbol }
        });
        DialogsById.Add(8, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.NiceResponseSymbol }
        });

        /*****************[FISHERMAN 1 {20-39}]**********************/
        DialogsById.Add(20, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FishermanSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.FishermanSymbol },
            OtherDialogNiceResponse = 22,
            OtherDialogBadResponse = 21
        });
        DialogsById.Add(21, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.FurySymbol },
        });
        DialogsById.Add(22, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 23,
            OtherDialogBadResponse = 21
        });
        DialogsById.Add(23, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.LeaderSymbol },
        });

        /*****************[BLACKSMITH 1 {40-59}]**********************/
        DialogsById.Add(40, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.BlacksmithSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 42,
            OtherDialogBadResponse = 41
        });
        DialogsById.Add(41, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol }
        });
        DialogsById.Add(42, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 43,
            OtherDialogBadResponse = 41
        });
        DialogsById.Add(43, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
        });

        /*****************[LEADER 2 {60-79}]**********************/
        DialogsById.Add(60, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 62,
            OtherDialogBadResponse = 61
        });

        DialogsById.Add(61, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol }
        });

        DialogsById.Add(62, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 64,
            OtherDialogBadResponse = 63
        });

        DialogsById.Add(63, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol, SymbolId.AskingSymbol, SymbolId.AskingSymbol }
        });

        DialogsById.Add(64, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.HeroSymbol, SymbolId.HelpSymbol, SymbolId.LeaderSymbol },
            OtherDialog = 65
        });

        DialogsById.Add(65, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.MoreFoodSymbol, SymbolId.VillageSymbol },
            OtherDialog = 66
        });

        DialogsById.Add(66, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.AnonymousSymbol },
            OtherDialog = 67
        });

        DialogsById.Add(67, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.FatherSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.Food2Symbol, SymbolId.Food2Symbol, SymbolId.Food2Symbol },
            OtherDialogNiceResponse = 68,
            OtherDialogBadResponse = 70
        });

        DialogsById.Add(68, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.TravelerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.Food2Symbol },
            OtherDialogNiceResponse = 71,
            OtherDialogBadResponse = -1
        });

        DialogsById.Add(69, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.FarmerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.Food2Symbol },
            OtherDialogNiceResponse = 7,
            OtherDialogBadResponse = 8
        });
        ///////BAD LINE
        DialogsById.Add(70, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.TravelerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.Food2Symbol },
            OtherDialogNiceResponse = 71,
            OtherDialogBadResponse = 71
        });
        DialogsById.Add(71, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.AskingSymbol, SymbolId.FarmerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.Food2Symbol },
            OtherDialogNiceResponse = 8,
            OtherDialogBadResponse = 8
        });
        /*****************[Father {80-85}]**********************/
        DialogsById.Add(80, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FatherSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.FatherSymbol },
            OtherDialogNiceResponse = 81,
            OtherDialogBadResponse = 2
        });
        DialogsById.Add(81, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol, SymbolId.FamilySymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.FamilySymbol, SymbolId.Food2Symbol },
        });
        /*****************[Traveler {85-90}]**********************/
        DialogsById.Add(85, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.TravelerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.TravelerSymbol },
            OtherDialogNiceResponse = 86,
            OtherDialogBadResponse = 2
        });
        DialogsById.Add(86, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.DaySymbol, SymbolId.NightSymbol, SymbolId.DaySymbol, SymbolId.NightSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.NightSymbol, SymbolId.DaySymbol },
        });
        /*****************[Farmer {91-95}]**********************/
        DialogsById.Add(91, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FarmerSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.FarmerSymbol },
            OtherDialogNiceResponse = 92,
            OtherDialogBadResponse = 2
        });
        DialogsById.Add(92, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.Food2Symbol },
            UnlockSymbols = new List<SymbolId>() { SymbolId.Food2Symbol },
        });

    }

    public static DialogObject GetDialogById(int id)
    {
        if (DialogsById.ContainsKey(id))
        {
            return DialogsById[id];
        }
        return null;
    }

}
