using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour
{
    public Button NoButton;
    public Button YesButton;
    public Image BGImage;
    public Text ConfText;

    // Start is called before the first frame update
    void Start()
    {
        HidePanel();
    }

    // Update is called once per frame
    public void HidePanel()
    {
        NoButton.GetComponentInChildren<Text>().enabled = false;
        NoButton.GetComponent<Image>().enabled = false;
        NoButton.enabled = false;
        YesButton.GetComponentInChildren<Text>().enabled = false;
        YesButton.GetComponent<Image>().enabled = false;
        YesButton.enabled = false;
        ConfText.enabled = false;
        BGImage.enabled = false;
        GetComponent<Image>().enabled = false;
    }

    public void ShowPanel()
    {
        NoButton.GetComponentInChildren<Text>().enabled = true;
        NoButton.GetComponent<Image>().enabled = true;
        NoButton.enabled = true;
        YesButton.GetComponentInChildren<Text>().enabled = true;
        YesButton.GetComponent<Image>().enabled = true;
        YesButton.enabled = true;
        ConfText.enabled = true;
        BGImage.enabled = true;
        GetComponent<Image>().enabled = true;
    }
}
