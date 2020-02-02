using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeMouseScript : MonoBehaviour
{
    public GameObject victoryPanel;
    public bool lostGame = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && victoryPanel.activeSelf == false)
        {
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.name.Substring(0,4) == "coke" && !lostGame)
                {
                    AudioManager.instance.Play("Cork");
                    victoryPanel.SetActive(true);
                    Debug.Log("Yay!");
                }
            }
        }
    }
}
