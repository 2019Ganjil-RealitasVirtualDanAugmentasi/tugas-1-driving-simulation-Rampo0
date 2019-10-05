using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : Controller
{
	private Rigidbody rb;
	[SerializeField] private float speed = 5f;
	[SerializeField] private float sensivity = 2f;
	private float frontAxis;
	private float horiAxis;
	private float steerAxis;
	private float brakeAxis;
	private float gasAxis;
	[SerializeField] private Transform steer;
	float maxAngle = 45f;
	bool steerType = false;

    void Awake()
    {
		rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
		if (controller == InputType.Xbox)
		{
			frontAxis = Input.GetAxis("gas");
			horiAxis = Input.GetAxis("xbox");
		}
		else if (controller == InputType.Keyboard)
		{
			frontAxis = Input.GetAxis("Vertical");
			horiAxis = Input.GetAxis("Horizontal");
		}
		else if (controller == InputType.Steer) {
			steerAxis = Input.GetAxis("Steer");
			brakeAxis = Input.GetAxis("Brake");
			gasAxis = Input.GetAxis("GasSteer");
			steerType = true;
		}

		//transform.Translate(new Vector3(0, 0, frontAxis * speed * Time.deltaTime), Space.Self);

		/*float direction = Vector3.Dot(transform.forward, rb.velocity.normalized);

		if (direction < 0)
		{
			transform.Rotate(new Vector3(0, -1 * horiAxis * sensivity, 0), Space.Self);
		}
		else if (direction > 0)
		{
			transform.Rotate(new Vector3(0, horiAxis * sensivity, 0), Space.Self);
		}*/

		//steer.Rotate(new Vector3(0, -(Mathf.Lerp(horiAxis,  horiAxis * 1.5f, 0.1f)), 0), Space.Self);
		//Debug.Log(steer.transform.eulerAngles);

		if (!steerType)
		{
			float angleRotation = horiAxis * maxAngle;
			steer.localEulerAngles = new Vector3(0, angleRotation, 0);

			transform.Rotate(new Vector3(0, horiAxis * sensivity, 0), Space.Self);

			Vector3 newPosition = rb.position + transform.TransformDirection(new Vector3(0, 0, frontAxis * speed * Time.deltaTime));
			rb.MovePosition(newPosition);
		}
		else {
			float angleRotation = -steerAxis * maxAngle;
			steer.localEulerAngles = new Vector3(0, angleRotation, 0);

			transform.Rotate(new Vector3(0, -steerAxis * sensivity, 0), Space.Self);
			if (gasAxis < 0)
			{
				Vector3 newPosition = rb.position + transform.TransformDirection(new Vector3(0, 0, -gasAxis * speed * Time.deltaTime));
				rb.MovePosition(newPosition);
			}

			if (brakeAxis < 0) {
				Vector3 newPosition = rb.position + transform.TransformDirection(new Vector3(0, 0, brakeAxis * speed * Time.deltaTime));
				rb.MovePosition(newPosition);
			}
		}



	}

}
