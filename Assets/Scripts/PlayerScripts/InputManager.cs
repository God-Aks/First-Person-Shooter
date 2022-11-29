using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput input;

    PlayerInput.OnFootActions onFoot;

    PlayerMovement movement;

    [SerializeField] GunBehaviour gun;

    [SerializeField] targetbehaviour target;

    //BurstFireBehaviour burstFire; 

    PlayerLook look;

    bool burst;

    // Start is called before the first frame update

    void Awake() { 
        input = new PlayerInput();
        onFoot = input.OnFoot;    
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        //burstFire = GetComponent<BurstFireBehaviour>();

        //Implementing callback for the basic movements and actions
        onFoot.Sprint.performed += ctx => movement.incSpeed();
        onFoot.Jump.performed += ctx => movement.Jump();
        onFoot.Fire.performed += ctx => gun.shoot();
        onFoot.PointReset.performed += ctx => target.GetComponent<targetbehaviour>().resetPoints();

        //if (onFoot.Fire.WasPressedThisFrame()) burst = true;

        //while (burst)
        //{
        //    gun.shoot();
        //    if (onFoot.Fire.WasReleasedThisFrame()) break;
        //}

        //burst = false;
            
        

        onFoot.PointReset.performed += ctx => target.resetPoints();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate() {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());    
    }

    private void OnDisable() {
        onFoot.Disable();    
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    
}
