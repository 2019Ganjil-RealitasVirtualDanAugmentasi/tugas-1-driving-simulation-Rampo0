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
	private float maxSpeed = 10;
	private float minSpeed = 7;

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

		DecreseSpeed();
	}

	public void IncreaseSpeed(float _speed) {
		speed += _speed;
		if (speed > maxSpeed) {
			speed = 10f;
		}
	}

	private void DecreseSpeed() {

		if (speed > minSpeed)
		{
			//Decrease speed make it 7f
			speed -= 0.005f;
		}
		
	}

}
