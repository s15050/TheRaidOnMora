using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowCamConButton : MonoBehaviour
{
    public Image controlsImage;
    private bool isVisible;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Text>().text = "Show Cam" + Environment.NewLine + "Controls";
        controlsImage.GetComponentInChildren<Text>().enabled = false;
        controlsImage.enabled = false;
        isVisible = false;
    }

    public void ShowOrHideCamControls()
    {
        if (isVisible)
        {
            GetComponentInChildren<Text>().text = "Show Cam" + Environment.NewLine + "Controls";
            controlsImage.GetComponentInChildren<Text>().enabled = false;
            controlsImage.enabled = false;
            isVisible = false;
        }
        else
        {
            GetComponentInChildren<Text>().text = "Hide Cam" + Environment.NewLine + "Controls";
            controlsImage.GetComponentInChildren<Text>().enabled = true;
            controlsImage.enabled = true;
            isVisible = true;
        }
    }
}
