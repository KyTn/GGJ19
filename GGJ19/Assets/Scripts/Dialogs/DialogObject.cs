using System.Collections.Generic;


public enum DialogType
{
    DialogFinalObject, InterDialogObject, NoDialogObject
}

public abstract class DialogObject
{
    public abstract DialogType DialogType { get; }
    public List<SymbolId> OtherSymbolsDialog;
}


public class DialogFinalObject : DialogObject
{
    public List<SymbolId> PlayerSymbolsNiceDialog;
    public List<SymbolId> OtherSymbolsNiceResponse;
    public List<SymbolId> OtherSymbolsBadResponse;

    public override DialogType DialogType => DialogType.DialogFinalObject;
}


public class InterDialogObject : DialogObject
{
    public List<SymbolId> PlayerSymbolsNiceDialog;
    public int OtherDialogNiceResponse;
    public int OtherDialogBadResponse;

    public override DialogType DialogType => DialogType.InterDialogObject;
}

public class NoDialogObject : DialogObject
{

    public override DialogType DialogType => DialogType.NoDialogObject;
}
