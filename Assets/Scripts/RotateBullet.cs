using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    public float zRot;

    void Start()
    {
        StartCoroutine(KillMe());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, zRot);
    }

    IEnumerator KillMe()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
