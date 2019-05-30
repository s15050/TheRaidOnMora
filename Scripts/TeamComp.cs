using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamComp : MonoBehaviour
{
    public Text pointsNumber;
    private int pointsTotal;

    public Text soldierNumber;
    private static int soldierCost = 10;

    public Text rangerNumber;
    private static int rangerCost = 15;

    public Text medicNumber;
    private static int medicCost = 20;

    public Text mageNumber;
    private static int mageCost = 15;

    public Text description;
    public Text costText;
    public Image tooltip;
    public Image effectTooltip;

    

    private int selected;
    private Text[] allNumbers;
    private int[] allAmounts;
    private static int[] allCosts = new int[4];
    private Text[] allTexts;
    private bool follower;
    private bool effected;
    private float tempDelay;

    // Start is called before the first frame update
    void Start()
    {
        //Reset
        SquadSaver.ResetComp();
        pointsTotal = 60;
        follower = false;
        effected = false;

        //Ustawienie w tablice
        allNumbers = new Text[4];
        allNumbers[0] = soldierNumber; allNumbers[1] = rangerNumber; allNumbers[2] = medicNumber; allNumbers[3] = mageNumber;
        allAmounts = new int[4];
        allAmounts[0] = 0; allAmounts[1] = 0; allAmounts[2] = 0; allAmounts[3] = 0;
        allCosts[0] = soldierCost; allCosts[1] = rangerCost; allCosts[2] = medicCost; allCosts[3] = mageCost;

        //Default
        SelectClass(0);

        //Zniknięcie panelu potwierdzenia
        

    }

    // Rozpoczęcie gry
    public void CommitSquadAndContinue()
    {
        SquadSaver.SaveAdventurerComp(allAmounts);
        SceneManager.LoadScene("Scenes/GameScene");
    }

    //Powrót do menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scenes/StartScreen");
    }

    //Tooltip
    public void TooltipCall(string code)
    {
        Text tttext = tooltip.GetComponentInChildren<Text>();
        switch (code)
        {
            case "+": tttext.text = "add a unit of this class to the team"; break;
            case "-": tttext.text = "remove a unit of this class from the team"; break;
            case "0": tttext.text = TextLibrary.GetAbilityDescription(selected, 0); break;
            case "1": tttext.text = TextLibrary.GetAbilityDescription(selected, 1); break;
            case "2": tttext.text = TextLibrary.GetAbilityDescription(selected, 2); break;
            case "3": tttext.text = TextLibrary.GetAbilityDescription(selected, 3); break;
            default: tttext.text = "Incorrect tooltip code"; break;
        }
        if (tttext.text.Length > 41)
        {
            tooltip.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 60);
            tttext.GetComponent<RectTransform>().sizeDelta = new Vector2(84, 55);
        }
        else
        {
            tooltip.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 30);
            tttext.GetComponent<RectTransform>().sizeDelta = new Vector2(84, 25);
        }

        if (tttext.text.Contains("Burning"))
        {
            effectTooltip.GetComponentsInChildren<Text>()[0].text = "Burning";
            effectTooltip.GetComponentsInChildren<Text>()[1].text = TextLibrary.GetEffectDescription("Burning");
            effected = true;
        }
        else if (tttext.text.Contains("Poisoned"))
        {
            effectTooltip.GetComponentsInChildren<Text>()[0].text = "Poisoned";
            effectTooltip.GetComponentsInChildren<Text>()[1].text = TextLibrary.GetEffectDescription("Poisoned");
            effected = true;
        }
        else if (tttext.text.Contains("shield"))
        {
            effectTooltip.GetComponentsInChildren<Text>()[0].text = "shield";
            effectTooltip.GetComponentsInChildren<Text>()[1].text = TextLibrary.GetEffectDescription("shield");
            effected = true;
        }
        else
            effected = false;
        tempDelay = 0f;
        follower = true;

    }

    public void TooltipRecall()
    {
        follower = false;
        tooltip.transform.position = new Vector2(2000, 0);
        if (effected)
        {
            effectTooltip.transform.position = tooltip.transform.position;
            effected = false;
        }

    }

    private void Update()
    {
        if (follower)
        {
            tempDelay += Time.deltaTime;
            if (tempDelay > 1f)
            {
                Vector3 tooltipPos = Input.mousePosition;
                tooltip.transform.position = tooltipPos;
                if (tooltip.GetComponent<RectTransform>().position.x > 800)
                    tooltip.GetComponent<RectTransform>().position -= new Vector3(40, 0);
                if (effected)
                {
                    effectTooltip.transform.position = tooltip.transform.position;
                }
            }
        }
    }

    //Wybieranie klasy
    public void SelectClass(int u)
    {
        selected = u;
        description.text = TextLibrary.GetDescription(selected);
        costText.text = "Cost: "+allCosts[selected];
    }

    //Dodawanie jednostki
    public void UnitPlus()
    {
        if (pointsTotal >= allCosts[selected])
        {
            pointsNumber.color = Color.white;
            allAmounts[selected]++;
            pointsTotal -= allCosts[selected];
            allNumbers[selected].text = allAmounts[selected] + "";
            pointsNumber.text = pointsTotal + "";
        }
        else
        {
            pointsNumber.color = Color.red;
        }
    }

    //Usuwanie jednostki
    public void UnitMinus()
    {
        if (allAmounts[selected] > 0)
        {
            pointsNumber.color = Color.white;
            allAmounts[selected]--;
            pointsTotal += allCosts[selected];
            allNumbers[selected].text = allAmounts[selected] + "";
            pointsNumber.text = pointsTotal + "";
        }
    }
}
