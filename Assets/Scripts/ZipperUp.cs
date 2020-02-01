using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZipperUp : MonoBehaviour
{
    public Slider slider;
    public GameObject victoryPanel;

    public GameObject[] picturePanels;

    private void Update()
    {
        SetZipper();
    }

    public void SetZipper()
    {
        if (slider.value == 3)
        {
            victoryPanel.SetActive(true);
            slider.enabled = false;
            return;
        }

        picturePanels[(int)slider.value].SetActive(true);

        if(slider.value > 0)
        {
            picturePanels[(int)slider.value-1].SetActive(false);
            picturePanels[(int)slider.value+1].SetActive(false);
        }
        if(slider.value == 0)
        {
            picturePanels[(int)slider.value+1].SetActive(false);
        }
    }
}
