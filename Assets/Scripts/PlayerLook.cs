using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
   [SerializeField]  public Camera cam;

   float Xrotation = 0f;

   [SerializeField] float Xsens = 30f;
   [SerializeField] float Ysens = 30f;

   public void ProcessLook(Vector2 input){

    float mouseX = input.x;
    float mouseY = input.y;

    Xrotation -= (mouseY * Time.deltaTime)*Xsens;

    Xrotation = Mathf.Clamp(Xrotation,-80f,80f);

    cam.transform.localRotation = Quaternion.Euler(Xrotation,0,0);

    transform.Rotate((Vector3.up * (mouseX * Time.deltaTime) *Ysens));

   }
}
