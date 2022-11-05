using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementbehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    bool moveorstat;

    public void movementtoggle()
    {
        target.GetComponent<targetbehaviour>().movement_or_teleport_toggle = moveorstat;

        moveorstat = !moveorstat;
    }

}
