using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OraksenSilmat : MonoBehaviour
{
    int rnd;
    int maxRnd = 5;
    int posRnd;

    LineRenderer lineRenderer;
    public Transform[] laserHits;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
        posRnd = Random.Range(0, 6);
    }
    void Update()
    {
        //Debug.Log(this.gameObject + " " + rnd);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);
        hit.point = laserHits[posRnd].position;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHits[posRnd].position);

        if (rnd == 0)
            StartCoroutine(quickLaser());
       
        if (rnd == 1)
            StartCoroutine(slowLaser());
        else
        {
            StartCoroutine(doNothing());

        }
    }

    IEnumerator quickLaser()
    {
        //Debug.Log("nopee");
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(1.5f);
        posRnd = Random.Range(0, 6);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
    }

    IEnumerator slowLaser()
    {
        //Debug.Log("Hidas");
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(2.5f);
        posRnd = Random.Range(0, 6);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
    }
    IEnumerator doNothing()
    {
        yield return new WaitForSeconds(5f);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
    }
}
