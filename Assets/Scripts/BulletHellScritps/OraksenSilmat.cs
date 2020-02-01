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

    bool canDo = true;

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

        if (rnd == 0 && canDo)
        {
            canDo = false;
            StartCoroutine(quickLaser());
        }
       
        if (rnd == 1 && canDo)
        {

            canDo = false;
            StartCoroutine(slowLaser());
        }
        else
        {
            StartCoroutine(doNothing());

        }
    }

    IEnumerator quickLaser()
    {
        lineRenderer.enabled = true;
        Debug.Log("TÄÄ");
        //laserSound.pitch
        yield return new WaitForSeconds(0.5f);
        posRnd = Random.Range(0, 6);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
        canDo = true;
    }

    IEnumerator slowLaser()
    {
        //Debug.Log("Hidas");
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(1f);
        posRnd = Random.Range(0, 6);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
        canDo = true;
    }
    IEnumerator doNothing()
    {
        yield return new WaitForSeconds(5f);
        lineRenderer.enabled = false;
        rnd = Random.Range(0, maxRnd);
    }
}
