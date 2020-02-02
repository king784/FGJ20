using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorasMouse : MonoBehaviour
{
    public void StartStun()
    {
        StartCoroutine(Stun());
    }
    public IEnumerator Stun()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(0.5f);
        Cursor.lockState = CursorLockMode.None;
    }
}
