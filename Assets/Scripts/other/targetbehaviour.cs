using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetbehaviour : MonoBehaviour
{

    [SerializeField] float timeBetweenRespawns;
    [SerializeField] GameObject[] targetpoints;
    [SerializeField] Text text;
    [SerializeField] float speed = 5f;
    public bool movement_or_teleport_toggle = true;
    bool regen = true;
    int randind;
    int points;

    public void die()
    {
        targetPointIncrement();
        if(movement_or_teleport_toggle) GetComponent<Renderer>().enabled = false;
        Invoke("respawn",timeBetweenRespawns);

    }

    private void Update()
    {
        if (!movement_or_teleport_toggle)
        {
            if (regen) 
            { 
                randind = Random.Range(0, targetpoints.Length);
                regen = false;
            }
            
            if (Vector3.Distance(transform.position, targetpoints[randind].transform.position) >= 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetpoints[randind].transform.position, speed*Time.deltaTime);
            }
            else
            {
                regen = true;
            }
        }
        
    }
    void respawn()
    {
        int randind = Random.Range(0,targetpoints.Length);
        if (movement_or_teleport_toggle)
        {
            transform.position = targetpoints[randind].transform.position;
        }
               
        GetComponent<Renderer>().enabled = true;
    }

    void targetPointIncrement()
    {
        points++;
        text.text = "Points : " + points.ToString();
    }

     public void resetPoints()
    {
        points = 0;
        text.text = "Points : " + points.ToString();
    }
}
