using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDiploma : MonoBehaviour
{
    public Button openDiplomaBtn;
    public GameObject firstCanvas;
    public GameObject secondCanvas;
    // Start is called before the first frame update
    void Start()
    {
        openDiplomaBtn.onClick.AddListener(OpenDiplomaFile);   
    }

    public void OpenDiplomaFile()
    {
        firstCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }
}
