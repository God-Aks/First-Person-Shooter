using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    Vector3 PlayerVelocity;
    public bool isGrounded;

    [SerializeField] float gravity = -9.8f;
    [SerializeField] float speed = 5f;

    [SerializeField] float JumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 movedir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        // ProcessMove(movedir);
        isGrounded = character.isGrounded;

        Debug.Log(PlayerVelocity.y);
    }

    public void ProcessMove(Vector3 input){

        Vector3 MoveDirection = new Vector3(input.x,0,input.y);

        character.Move(transform.TransformDirection(MoveDirection) * speed * Time.deltaTime);
        PlayerVelocity.y += gravity*Time.deltaTime;

        if(isGrounded && PlayerVelocity.y <0)
            PlayerVelocity.y = -2f;
        character.Move(PlayerVelocity*Time.deltaTime);

    }

    public void Jump(){
        if(isGrounded)
            PlayerVelocity.y = Mathf.Sqrt(JumpHeight * gravity * -2f);
    }
  
}
