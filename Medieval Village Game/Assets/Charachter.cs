using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charachter : MonoBehaviour
{
private CharacterController controller;

private float verticalVelocity;
private float gravity = 14.0f;
private float jumpForce = 7.0f;
private float rotationSpeed = 20.0f;

private float rotX;
private float rotY;
private float rotZ;

private void Start(){
  controller = GetComponent<CharacterController>();

}
private void Update(){
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
  moveVector.x = Input.GetAxis("Horizontal") * 2.0f;
  moveVector.y = verticalVelocity;
  moveVector.z = Input.GetAxis("Vertical") * 2.0f;
  controller.Move(moveVector*Time.deltaTime);

  rotX = rotX + Input.GetAxis("MouseY") * Time.deltaTime * rotationSpeed;
  rotY = rotY - Input.GetAxis("MouseX") * Time.deltaTime * rotationSpeed;

  transform.rotation = Quaternion.Euler(0,rotY,0);
  }

}
