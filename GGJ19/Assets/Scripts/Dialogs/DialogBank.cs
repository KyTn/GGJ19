using System.Collections.Generic;

public class DialogBank
{

    private static Dictionary<int, DialogObject> DialogsById = new Dictionary<int, DialogObject>();

    static DialogBank()
    {
        DialogsById.Add(1, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { SymbolId.LeaderSymbol },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { SymbolId.HeroSymbol },
            OtherDialogNiceResponse = 2,
            OtherDialogBadResponse = 3
        });

        DialogsById.Add(2, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { /* ... */ },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { /* ... */ },
            //OtherDialogNiceResponse = ...,
            //OtherDialogBadResponse =...
        });

        DialogsById.Add(3, new InterDialogObject()
        {
            OtherSymbolsDialog = new List<SymbolId>() { /* ... */ },
            PlayerSymbolsNiceDialog = new List<SymbolId>() { /* ... */ },
            //OtherDialogNiceResponse = ...,
            //OtherDialogBadResponse =...
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
