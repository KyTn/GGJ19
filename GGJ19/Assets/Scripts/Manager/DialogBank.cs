using System.Collections.Generic;

public class DialogBank
{

    private static Dictionary<int, DialogObject> DialogsById = new Dictionary<int, DialogObject>();

    static DialogBank()
    {

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
