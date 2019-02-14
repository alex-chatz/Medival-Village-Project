using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationPicker : MonoBehaviour {

	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;
  public float height = 50;
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	Animator anim;
	int AnimChoose;
	float speed ;

	// Update is called once per frame
	void Start () {

		controller = GetComponent<CharacterController>();
		// controller.height = height;
		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

			anim = GetComponent<Animator> ();
			anim.speed = speed = 1 * (Random.Range (.5f, 1.5f));

			AnimChoose = Random.Range(1,3);
			anim.SetInteger("Idle", AnimChoose);

		StartCoroutine(NewHeading());
	}
	void Upadte(){
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}
	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}
}
