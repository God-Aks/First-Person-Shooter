using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBtnBehaviour : MonoBehaviour
{
    [SerializeField] Transform gameobj;
    bool moving = true;

    public void movementToggle()
    {
        if (moving)
        {
            gameobj.GetComponent<PlayerMovement>();
        }
        
    }
}
