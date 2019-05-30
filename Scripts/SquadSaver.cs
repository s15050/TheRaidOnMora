using System.Collections;
using System.Collections.Generic;

public class SquadSaver
{
    static int[] adventurerComp = { 0, 0, 0, 0 }; //0 - soldiers, 1 - rangers, 2 - medics, 3 - mages

    public static void ResetComp()
    {
        adventurerComp = new int[4];
        for (int i = 0; i < 4; i++)
            adventurerComp[i] = 0;
    }

    public static void SaveAdventurerComp(int[] comp)
    {
        for (int i = 0; i < 4; i++)
            adventurerComp[i] = comp[i];
    }

    public static int[] GetAdventurerComp()
    {
        return adventurerComp;
    }
}
