using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charachter : MonoBehaviour
{
private CharacterController controller;
private float verticalVelocity;
private float gravity = 14.0f;
private float jumpForce = 5.0f;
private float rotationSpeed = 20.0f;
public Transform pivot;
private float distance = 5;
static Animator anim;
private float rotX;
private float rotY;
private float rotZ;


private void Start(){
  controller = GetComponent<CharacterController>();
  anim = GetComponent<Animator>();
  anim.SetBool("IsRunning", false);


}
private void Update(){
  // transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

  if (controller.isGrounded) {
    verticalVelocity = -gravity * Time.deltaTime;
    if (Input.GetKeyDown(KeyCode.Space)) {
      verticalVelocity = jumpForce;
    }
  }
  else{
    verticalVelocity -= gravity * Time.deltaTime;
  }
  Vector3 moveVector = Vector3.zero;
  moveVector.x = Input.GetAxis("Horizontal") * 10.0f;
  moveVector.y = verticalVelocity;
  moveVector.z = Input.GetAxis("Vertical") * 10.0f;
  // Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
  moveVector = Camera.main.transform.TransformDirection(moveVector);
  controller.Move(moveVector*Time.deltaTime);
  if (Input.GetKeyDown(KeyCode.W))
        {
          anim.SetBool("IsRunning", true);
        }
  else{
    anim.SetBool("IsRunning", false);

  }
  // anim.SetTrigger("run");


  // moveVector.y = 0.0f;

  rotX = rotX + Input.GetAxis("MouseY") * Time.deltaTime * rotationSpeed;
  rotY = rotY - Input.GetAxis("MouseX") * Time.deltaTime * rotationSpeed;

  transform.rotation = Quaternion.Euler(0,rotY,0);
  // transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

  // transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
  }

}
