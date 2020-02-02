using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    public float zRot;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, zRot);
    }
}
