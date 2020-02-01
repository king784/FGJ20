using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OraksenSilmat : MonoBehaviour
{
    int rnd;

    private void Start()
    {
        rnd = Random.Range(0, 2);
    }
    void Update()
    {
        if (rnd == 0)
            StartCoroutine(quickRoll());

        if (rnd == 1)
            StartCoroutine(slowRoll());
    }

    IEnumerator quickRoll()
    {
        //Debug.Log("nopee");
        this.transform.Rotate(0, 0, 10);
        yield return new WaitForSeconds(3);
        rnd = Random.Range(0, 2);
    }

    IEnumerator slowRoll()
    {
        //Debug.Log("Hidas");
        this.transform.Rotate(0, 0, 2);
        yield return new WaitForSeconds(10);
        rnd = Random.Range(0, 2);
    }
}
