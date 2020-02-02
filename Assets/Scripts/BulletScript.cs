using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnMouseOver()
    {
        FindObjectOfType<MorasMouse>().StartStun();
    }
}
