using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHellScript : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject lEye;
    public GameObject rEye;
    public GameObject moras;
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(ShootAround());
    }
    
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

    IEnumerator ShootAround()
    {
        float a = 360/100;
        Vector3 morasUp = moras.transform.up;
        for(int i = 0; i < 100; i++)
        {
            morasUp = Quaternion.Euler(0, 0, a*i) * morasUp;
            GameObject obj = Instantiate(bullet, lEye.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(morasUp * 5.0f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
