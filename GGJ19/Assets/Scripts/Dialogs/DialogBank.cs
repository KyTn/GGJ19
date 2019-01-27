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
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 7,
            OtherDialogBadResponse = 6
        });

        DialogsById.Add(7, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { /*SymbolId.BadResponseSymbol*/ }
        });
        DialogsById.Add(8, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { /*SymbolId.NiceResponseSymbol*/ }
        });

        /*****************[FISHERMAN 1 {20-39}]**********************/
        DialogsById.Add(20, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FishermanSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 22,
            OtherDialogBadResponse = 21
        });
        DialogsById.Add(21, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol }
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
        });

        /*****************[BLACKSMITH 1 {40-39}]**********************/
        DialogsById.Add(40, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.BlacksmithSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 22,
            OtherDialogBadResponse = 21
        });
        DialogsById.Add(41, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.FurySymbol }
        });
        DialogsById.Add(42, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.AskingSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.FireSymbol },
            OtherDialogNiceResponse = 23,
            OtherDialogBadResponse = 21
        });
        DialogsById.Add(43, new NoDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
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
