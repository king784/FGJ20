using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiplomaName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = System.Environment.UserName;
    }
}
