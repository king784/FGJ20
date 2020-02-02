﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level3Manager : MonoBehaviour
{
    public Image timerImage;
    public GameObject loseCanvas;

    // Update is called once per frame
    void Update()
    {
        if(timerImage.fillAmount == 0)
        {
            Debug.Log("Game Over! Fridge is overflooding with bottles");
            LevelManager.LevelMaster.AddToGrade(-0.5f);
            loseCanvas.SetActive(true);
        } else
        {
            timerImage.fillAmount -= Time.deltaTime * 0.08f;
            if (timerImage.color.r < 1)
                timerImage.color = new Color(timerImage.color.r + 0.002f, timerImage.color.g, timerImage.color.b);
            else
                timerImage.color = new Color(timerImage.color.r, timerImage.color.g - 0.002f, timerImage.color.b);

        }
    }
}
