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
    bool shooting = true;

    void Start()
    {
        StartCoroutine(ShootRoutine());
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

    IEnumerator ShootRoutine()
    {
        while(shooting)
        {
            yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));
            StartCoroutine(ShootLeftEyeAround());
            StartCoroutine(ShootRightEyeAround());
        }
    }

    IEnumerator ShootLeftEyeAround()
    {
        float a = 360/100;
        Vector3 morasUp = moras.transform.up;
        for(int i = 0; i < 50; i++)
        {
            morasUp = Quaternion.Euler(0, 0, a*i) * morasUp;
            GameObject obj = Instantiate(bullet, lEye.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(morasUp * 5.0f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ShootRightEyeAround()
    {
        float a = 360/100;
        Vector3 morasUp = moras.transform.up;
        for(int i = 0; i < 50; i++)
        {
            morasUp = Quaternion.Euler(0, 0, a*i) * morasUp;
            GameObject obj = Instantiate(bullet, rEye.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(morasUp * 5.0f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
