using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Glitch")){
            other.transform.GetComponent<GlitchChangeScene>().moveToGlitchedWorld();
        }
    }
}
