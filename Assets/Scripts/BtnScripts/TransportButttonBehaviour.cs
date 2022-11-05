using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportButttonBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform spawnpoint;

    [SerializeField]
    Transform PlayerObj;

    public void Transport()
    {
        PlayerObj.transform.position = spawnpoint.transform.position;
    }

}
