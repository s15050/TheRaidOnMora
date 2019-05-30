using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphical : MonoBehaviour
{
    //Class names (for changing colors)
    public Text soldierText;
    public Text rangerText;
    public Text medicText;
    public Text mageText;

    //Class sprites (for changing sprites)
    public Sprite soldierSprite;
    public Sprite rangerSprite;
    public Sprite medicSprite;
    public Sprite mageSprite;

    public Image preview;

    //Class ability sprites
    public Sprite[] soldierAbilities = new Sprite[3];
    public Sprite[] rangerAbilities = new Sprite[3];
    public Sprite[] medicAbilities = new Sprite[3];
    public Sprite[] mageAbilities = new Sprite[4];

    //Ability images
    public Image[] abilityImages = new Image[4];


    // Start is called before the first frame update
    void Start()
    {
        SetTextColor(0);
    }

    public void SetTextColor(int u)
    {
        switch (u)
        {
            case 0:
                soldierText.color = Color.black; rangerText.color = Color.white; medicText.color = Color.white; mageText.color = Color.white;
                break;
            case 1:
                soldierText.color = Color.white; rangerText.color = Color.black; medicText.color = Color.white; mageText.color = Color.white;
                break;
            case 2:
                soldierText.color = Color.white; rangerText.color = Color.white; medicText.color = Color.black; mageText.color = Color.white;
                break;
            case 3:
                soldierText.color = Color.white; rangerText.color = Color.white; medicText.color = Color.white; mageText.color = Color.black;
                break;
            default:
                soldierText.color = Color.white; rangerText.color = Color.white; medicText.color = Color.white; mageText.color = Color.white;
                break;
        }
        SetSprite(u);
        SetAbilityImages(u);
    }

    private void SetSprite(int u)
    {
        Sprite setsprite;
        switch(u)
        {
            case 0: setsprite = soldierSprite; break;
            case 1: setsprite = rangerSprite; break;
            case 2: setsprite = medicSprite; break;
            case 3: setsprite = mageSprite; break;
            default: setsprite = soldierSprite; break;
        }
        preview.sprite = setsprite;
    }

    private void SetAbilityImages(int u)
    {
        int c = TextLibrary.NoOfAbilities(u);
        abilityImages[3].enabled = true;
        for (int i = 0; i < c; i++)
        {
            switch (u)
            {
                case 0: abilityImages[i].sprite = soldierAbilities[i]; break;
                case 1: abilityImages[i].sprite = rangerAbilities[i]; break;
                case 2: abilityImages[i].sprite = medicAbilities[i]; break;
                case 3: abilityImages[i].sprite = mageAbilities[i]; break;
                default: abilityImages[i].sprite = soldierAbilities[i]; break;
            }
            Text txt = abilityImages[i].GetComponentInChildren<Text>();
            txt.text = TextLibrary.GetAbilityName(u, i);
        }
        if (c < 4)
        {
            abilityImages[3].enabled = false;
            abilityImages[3].GetComponentInChildren<Text>().text = "";
        }

    }
}
