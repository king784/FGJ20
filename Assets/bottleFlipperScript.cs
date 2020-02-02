using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleFlipperScript : MonoBehaviour
{
    public GameObject[] bottleObjects;
    bool ReadyToFlip;
    bool flipping = true;
    GameObject bottle;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Glitch");
        ReadyToFlip = true;
        StartCoroutine(WaitForRandomFlips());
    }

    IEnumerator WaitForRandomFlips()
    {
        while(flipping)
        {
            ReadyToFlip = false;
            float timeW = Random.Range(2f, 5f);
            yield return new WaitForSeconds(timeW);
            bottle = Instantiate(bottleObjects[Random.Range(0, bottleObjects.Length - 1)], transform);
            AudioManager.instance.Play("Swish");
            Vector3 forcVec = transform.up * 10;
            forcVec.x += Random.Range(-0.5f, 0.5f);
            bottle.GetComponent<Rigidbody>().AddForce(forcVec, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(1f, 5f));
            ReadyToFlip = true;
        } 
    }
}
