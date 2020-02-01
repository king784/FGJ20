using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZipperUp : MonoBehaviour
{
    public Slider slider;
    public GameObject togle;
    public GameObject victoryPanel;

    private void Update()
    {
        SetZipper();
    }

    public void SetZipper()
    {
       if(slider.value == 0)
        {
            slider.enabled = false;
            victoryPanel.SetActive(true);
        }
    }

}
