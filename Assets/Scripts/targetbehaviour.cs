using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void die()
    {
        Getcomponent<Renderer>().enabled = false;
    }

    void respawn()
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnpoint = new Vector2(spawnX,spawnY);
        Instantiate(gameObject,spawnpoint,Quartenion.Identity);
    }
}
