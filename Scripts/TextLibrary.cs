using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLibrary : MonoBehaviour
{
    //Class flavour text
    private static string[] descriptions = {
        //Soldier
        "Ordinary soldiers form the bulk of the New Union military. Their chief responsibility is to protect the trade routes and cities " +
            "of the Union from the Malignancy, although in recent years, they are also sent out on recovery missions into the abandoned " +
            "territories. It's not uncommon for them not to return.",

        //Ranger
        "In the early years after the Malignancy came, a new social class has formed. Called Forerunners, Scouts or Rangers, they traverse " +
            "the vast distances between the cities all by themselves, seeking to map, cleanse, or simply explore them. In the army, those " +
            "stealth specialists are invaluable, though their social skills leave something to be desired.",

        //Medic
        "With the breakdown of infrastructure that accompanied a giant invasion from the beyond, medicine became crucial. It is no wonder, " +
            "then, that doctors were the first to discover that magic became more powerful with the Malignancy's arrival. Though there " +
            "are ordinary medics still, in the field, one is more likely to find a healer-mage.",

        //Mage
        "There were hexers before the Malignancy came; people who could alter a dice toss or curdle milk. But when the Gate opened, they " +
            "found their powers increased hundredfold and today, even the weakest mage is capable of immense destruction. Though some consider " +
            "the coincidence a proof that mages are unholy, they are too useful to delegalize."};

    //Class abilities
    private static string[] soldierAbiNames = { "Double-tap", "Fortify", "Grenade" };
    private static string[] rangerAbiNames = { "Ghost", "Focus", "Cover fire" };
    private static string[] medicAbiNames = { "Heal", "Zone Heal", "Cleanse" };
    private static string[] mageAbiNames = { "Shield", "Poison Field", "Inspiration", "Conflagration" };
    private static string[][] abiNames = { soldierAbiNames, rangerAbiNames, medicAbiNames, mageAbiNames };

    //Class ability descriptions
    //Soldier
    private static string[] soldierAbiDesc = {
        "fire twice at the same enemy",
        "take half damage from the next enemy attack",
        "throw a grenade that deals X damage in range of Y"};

    //Ranger
    private static string[] rangerAbilityDesc = {
        "cannot be attacked until making the next action",
        "aim increased by X% until next shot",
        "during enemy turn, automatically take shot at half aim at the first enemy to attack an ally"};

    //Medic
    private static string[] medicAbilityDesc = {
        "restore 4 HP to one ally",
        "restore 2 HP to all allies in range of X",
        "remove all negative status effects from an ally"};

    //Mage
    private static string[] mageAbilityDesc = {
        "give 3 shield points to an ally",
        "give all enemies in range Poisoned",
        "give all allies +1 to damage, aim and move",
        "give all enemies in range Burning"};

    private static string[][] abiDesc = { soldierAbiDesc, rangerAbilityDesc, medicAbilityDesc, mageAbilityDesc };

    //Effects
    private static string[] burning = { "Burning", "move limited by 2; at every action, takes 1 damage; T/O 3" };
    private static string[] poisoned = { "Poisoned", "takes 1 damage at the end of its turn; T/O 2" };
    private static string[] shielded = { "shield", "extra HP points that cannot be recoved by healing" };

    private static string[][] effects = { burning, poisoned, shielded };

    //Namebase (players)
    private static string[] namebase = { "Lia", "Shanna", "Astarte", "Meseret", "Salome", "Amanda", "Charley", "Mira", "Yuki",
                                         "Calla", "Rita", "Septe", "Meryiel", "Rasarr", "Titania", "Samantha", "Tiamat", "Min" };
    private static List<string> nameslist = new List<string>();
    public static void MakeList()
    {
        nameslist = new List<string>();
        nameslist.AddRange(namebase);
    }

    //Namebase (monster)
    private static string[] monsterbase = { "Fafnir", "Puka", "Fenrir", "Sja-anat", "Shoggoth", "Ayuwoki",
                                            "Dee", "Dum", "Yoofoh", "Yogi", "Svartalf", "Vulf", "Nepthys"};
    private static List<string> monsterlist = new List<string>();
    public static void MakeMonsterList()
    {
        monsterlist = new List<string>();
        monsterlist.AddRange(monsterbase);
    }

    //Gives description of an adventurer class
    public static string GetDescription(int i)
    {
        return descriptions[i];
    }

    //Gives number of abilities a given class has
    public static int NoOfAbilities(int i)
    {
        return abiNames[i].Length;
    }

    //Gives name of nr-th ability of a type unit
    public static string GetAbilityName(int type, int nr)
    {
        return abiNames[type][nr];
    }

    //Gets description of nr-th ability of a type unit
    public static string GetAbilityDescription(int type, int nr)
    {
        return abiDesc[type][nr];
    }

    //Gets description of an effect
    public static string GetEffectDescription(string name)
    {
        foreach (string[] a in effects)
        {
            if (a[0].Equals(name))
            {
                return a[1];
            }
        }
        return "No such effect found";
    }

    //Gives a random name from the "namebase" table
    public static string GetHumanUnitName()
    {
        System.Random gen = new System.Random();
        int i = gen.Next(0, (nameslist.Count - 1));
        string newName = nameslist[i];
        nameslist.Remove(newName);
        return newName;
    }

    //Gives a random name from the "monsterbase" table
    public static string GetMonsterUnitName()
    {
        System.Random gen = new System.Random();
        int i = gen.Next(0, (monsterlist.Count - 1));
        string newName = monsterlist[i];
        monsterlist.Remove(newName);
        return newName;
    }
}
