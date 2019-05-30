using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSquad : MonoBehaviour
{
    public GameObject Mage;
    public GameObject Medic;
    public GameObject Ranger;
    public GameObject Soldier;
    public static int[] squad = new int[4];
    public Transform newParent;
    private int j;
    private string[] names;

    //Do imion
    public Text UIIndivNameText;
    public Text UIClassNameText;
    //Do podświetlania jednostki
    public GameObject token;
    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("Hhhhh.");

        j = 0;

        for (int i = 0; i < 4; i++)
            squad[i] = SquadSaver.GetAdventurerComp()[i];
        string testing = squad[0] + "; " + squad[1] + "; " + squad[2] + "; " + squad[3];

        //Wymagane do załadowania imion
        TextLibrary.MakeList();
        RollNames();
        int k = 0;

        /*GameObject ziom = Instantiate(Soldier, newParent);
        ziom.transform.position = new Vector3(5, 5, 0);
        Instantiate(Soldier, newParent);*/

        for (int i = 0; i < squad[0]; i++)
        {
            GameObject zjom = Instantiate(Soldier, newParent);
            zjom.GetComponent<Unit>().UIIndivNameText = UIIndivNameText;
            zjom.GetComponent<Unit>().UINameText = UIClassNameText;
            zjom.GetComponent<AbsoluteUnit>().token = token;
            //Losowanie imienia
            zjom.GetComponent<AbsoluteUnit>().unitName = names[k];
            k++;
            zjom.transform.position = new Vector3(j, 0, 0);
            j = j + 1 ;
            //Debug.Log("Wykonano " + i);
        }

        for (int i = 0; i < squad[1]; i++)
        {
            GameObject zjom = Instantiate(Ranger, newParent);
            zjom.GetComponent<Unit>().UIIndivNameText = UIIndivNameText;
            zjom.GetComponent<Unit>().UINameText = UIClassNameText;
            zjom.GetComponent<AbsoluteUnit>().token = token;
            //Losowanie imienia
            zjom.GetComponent<AbsoluteUnit>().unitName = names[k];
            k++;
            zjom.transform.position = new Vector3(j, 0, 0);
            j = j + 1;
            //Debug.Log("Wykonano " + i);
        }

        for (int i = 0; i < squad[2]; i++)
        {
            GameObject zjom = Instantiate(Medic, newParent);
            zjom.GetComponent<Unit>().UIIndivNameText = UIIndivNameText;
            zjom.GetComponent<Unit>().UINameText = UIClassNameText;
            zjom.GetComponent<AbsoluteUnit>().token = token;
            //Losowanie imienia
            zjom.GetComponent<AbsoluteUnit>().unitName = names[k];
            k++;
            zjom.transform.position = new Vector3(j, 0, 0);
            j = j + 1;
            //Debug.Log("Wykonano " + i);
        }

        for (int i = 0; i < squad[3]; i++)
        {
            GameObject zjom = Instantiate(Mage, newParent);
            zjom.GetComponent<Unit>().UIIndivNameText = UIIndivNameText;
            zjom.GetComponent<Unit>().UINameText = UIClassNameText;
            zjom.GetComponent<AbsoluteUnit>().token = token;
            //Losowanie imienia
            zjom.GetComponent<AbsoluteUnit>().unitName = names[k];
            k++;
            zjom.transform.position = new Vector3(j, 0, 0);
            j = j + 1;
            //Debug.Log("Wykonano " + i);
        }

    }

    //Losowanie imion
    private void RollNames()
    {
        int squadsize = 0;
        for (int i = 0; i < 4; i++)
        {
            squadsize += squad[i];
        }
        names = new string[squadsize];
        for (int i = 0; i < squadsize; i++)
        {
            names[i] = TextLibrary.GetHumanUnitName();
        }
    }
}
