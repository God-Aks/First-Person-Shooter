using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    Vector3 PlayerVelocity;
    public bool isGrounded;

    [SerializeField] float gravity = -9.8f;
    [SerializeField] public float speed = 5f;
    float minspeed = 5f;
    float maxspeed = 10f;

    [SerializeField] public float JumpHeight = 3f;

    bool speedbehav = false;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speedbehav)
        {
            Debug.Log("Sprinting");
            if (speed != maxspeed)
            {
                incSpeed();
            }
            
        }
        else
        {
            if(speed != minspeed)
            {
                decSpeed();
            }
            
        }
        isGrounded = character.isGrounded;

        //Debug.Log(PlayerVelocity.y);
    }

    public void ProcessMove(Vector3 input){

        Vector3 MoveDirection = new Vector3(input.x,0,input.y);

        character.Move(transform.TransformDirection(MoveDirection) * speed * Time.deltaTime);
        PlayerVelocity.y += gravity*Time.deltaTime;

        if(isGrounded && PlayerVelocity.y <0)
            PlayerVelocity.y = -9.8f;
        character.Move(PlayerVelocity*Time.deltaTime);

    }

    public void Jump(){
        if(isGrounded)
            PlayerVelocity.y = Mathf.Sqrt(JumpHeight * gravity * -2f);
    }

    public void incSpeed()
    {
        speed += 5f;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    }

    public void decSpeed()
    {
        speed -= 5f;
    }

    public void speedbehaviour()
    {
        speedbehav = !speedbehav;
    }
  
}
