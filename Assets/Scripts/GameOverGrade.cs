using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverGrade : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    void OnEnable()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text += LevelManager.LevelMaster.Grade.ToString();
    }
}
