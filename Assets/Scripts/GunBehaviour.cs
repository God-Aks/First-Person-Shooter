using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public float firerate = 15f;

    public float ompactforce = 30f;

    float nexttimetofire = 0f;
    [SerializeField] Camera cam;

    [SerializeField] ParticleSystem muzzleflash;

    [SerializeField] GameObject impacteffect;
    void Awake()
    {
        muzzleflash.Pause();
        // impacteffect.GetComponent<ParticleSystem>().playbackSpeed = 10f;
    }

   
    void Update()
    {
        
    }

    public void shoot(){

        if(Time.time >= nexttimetofire)
        {
            nexttimetofire = Time.time + 1f/firerate ;

            muzzleflash.Play();
            RaycastHit hitInfo;

            if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo,range))
            {
                EnemyBehaviour target = hitInfo.transform.GetComponent<EnemyBehaviour>();

                if(target!=null)
                {
                    target.TakeDamage(damage);
                }
            }
            Instantiate(impacteffect,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
            Invoke("muzzleflashstop",0.3f);
        }
    }

    void muzzleflashstop()
    {
        muzzleflash.Stop();
    }
}
