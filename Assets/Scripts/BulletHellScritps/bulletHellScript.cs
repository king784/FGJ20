using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHellScript : MonoBehaviour
{
    public ParticleSystem particle;
    void Update()
    {
        ParticleSystem newParticle;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);

        if (Physics.Raycast(ray))
        {
            newParticle = Instantiate(particle, ray.origin, transform.rotation);
           // Debug.Log(newParticle);
        }
    }
}
