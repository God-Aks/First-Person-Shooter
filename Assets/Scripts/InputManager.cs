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

    PlayerLook look;
    // Start is called before the first frame update
    void Awake() {
        input = new PlayerInput();
        onFoot = input.OnFoot;    
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => movement.Jump();
        onFoot.Fire.performed += ctx => gun.shoot();
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
