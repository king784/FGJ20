using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeMouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.name.Substring(0,4) == "coke")
                {
                    Debug.Log("Yay!");
                }
            }
        }
    }
}
