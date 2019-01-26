using System.Collections.Generic;


public enum DialogType
{
    InterDialogObject, NoDialogObject
}

public abstract class DialogObject
{
    public abstract DialogType DialogType { get; }
    public List<SymbolId> OtherSymbolsDialog;
}

// con este termina, continua o empieza un dialogo
// con respuesta esperada
// un null en una response => fin dialogo
public class InterDialogObject : DialogObject
{
    public List<SymbolId> PlayerSymbolsNiceDialog;
    public List<SymbolId> OtherSymbolsNiceResponse;
    public List<SymbolId> OtherSymbolsBadResponse;
    public int? OtherDialogNiceResponse;
    public int? OtherDialogBadResponse;

    public override DialogType DialogType => DialogType.InterDialogObject;
}

// con este termina, continua o empieza un monologo
// sin respuesta esperada
// un null en una response => fin monologo
public class NoDialogObject : DialogObject
{
    public override DialogType DialogType => DialogType.NoDialogObject;
    public int? OtherDialog;
}
