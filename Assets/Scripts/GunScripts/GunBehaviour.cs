using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

   

    public float impactforce = 30f;

    
    [SerializeField] Camera cam;

    [SerializeField] ParticleSystem muzzleflash;

    [SerializeField] GameObject impacteffect;

    float nexttimetofire = 0f;

    public float firerate = 15f;

    void Awake()
    {
        muzzleflash.Pause();
        // impacteffect.GetComponent<ParticleSystem>().playbackSpeed = 10f;
    }

    public void shoot(){

        if (Time.time >= nexttimetofire)
        {
            nexttimetofire = Time.time + 1f / firerate;
            muzzleflash.Play();
            RaycastHit hitInfo;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
            {
                Debug.Log(hitInfo.collider.name);
                EnemyBehaviour enemy = hitInfo.transform.GetComponent<EnemyBehaviour>();
                targetbehaviour target = hitInfo.transform.GetComponent<targetbehaviour>();
                TransportButttonBehaviour transportbtn = hitInfo.transform.GetComponent<TransportButttonBehaviour>();
                MovementBtnBehaviour movebtn = hitInfo.transform.GetComponent<MovementBtnBehaviour>();
                TargetMovementbehaviour targetmovebtn = hitInfo.transform.GetComponent<TargetMovementbehaviour>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                if (target != null)
                {
                    target.die();
                }

                if (transportbtn)
                {
                    transportbtn.Transport();
                }

                if (movebtn)
                {
                    movebtn.movementToggle();
                }

                if (targetmovebtn)
                {
                    targetmovebtn.movementtoggle();
                }
            }
            Instantiate(impacteffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Invoke("muzzleflashstop", 0.3f);
        }


        
    }

    void muzzleflashstop()
    {
        muzzleflash.Stop();
    }
}
