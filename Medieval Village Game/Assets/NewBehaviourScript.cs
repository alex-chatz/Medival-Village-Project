using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  public Transform camPivot;
  float heading = 0;
  public Transform cam;


  Vector2 input;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        heading += Input.GetAxis("MouseX") * Time.deltaTime*180;
        camPivot.rotation = Quaternion.Euler(0,heading,0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);


        //transform.position += new Vector3(input.x,0,input.y) * Time.deltaTime*5;
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

 transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
