﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleFlipperScript : MonoBehaviour
{
    public GameObject[] bottleObjects;

    GameObject bottle;
    // Start is called before the first frame update
    void Start()
    {
        bottle =  Instantiate(bottleObjects[Random.Range(0, bottleObjects.Length - 1)], transform);
        Vector3 forcVec = transform.up * 10;
        forcVec.x += Random.Range(-0.5f, 0.5f);
        bottle.GetComponent<Rigidbody>().AddForce( forcVec,ForceMode.Impulse);
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

        StartCoroutine(WaitForRandomFlips());
    }

    IEnumerator WaitForRandomFlips()
    {
        float timeW = Random.Range(5f, 60f);
        yield return new WaitForSeconds(timeW);
        bottle = Instantiate(bottleObjects[Random.Range(0, bottleObjects.Length - 1)], transform);
        Vector3 forcVec = transform.up * 10;
        forcVec.x += Random.Range(-0.5f, 0.5f);
        bottle.GetComponent<Rigidbody>().AddForce(forcVec, ForceMode.Impulse);
    }
}