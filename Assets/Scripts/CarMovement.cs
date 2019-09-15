using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
	// Start is called before the first frame update

	private Rigidbody rb;
	[SerializeField] private float speed = 5f;
	[SerializeField] private float sensivity = 2f;
	//private Vector3 direction;

    void Start()
    {
		rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(Input.GetAxis("xbox"));
		//Debug.Log(Input.GetAxis("gas"));
		float frontAxis = Input.GetAxis("gas");
		float horiAxis = Input.GetAxis("xbox");

		//transform.Translate(new Vector3(0, 0, frontAxis * speed * Time.deltaTime), Space.Self);
		//rb.velocity = transform.forward * frontAxis * speed;

		rb.AddForce(transform.forward * frontAxis * speed * speed, ForceMode.Acceleration);

		/*if (frontAxis > 0)
		{
			rb.velocity = transform.forward * frontAxis * speed;
		//	direction = new Vector3
			
		}
		else {
			rb.velocity = transform.forward * frontAxis * speed;
		}*/


		float direction = Vector3.Dot(transform.forward, rb.velocity.normalized);
		Debug.Log(direction);

		if (direction < 0)
		{
			transform.Rotate(new Vector3(0, -1 * horiAxis * sensivity, 0), Space.Self);
		}
		else if(direction > 0){
			transform.Rotate(new Vector3(0, horiAxis * sensivity, 0), Space.Self);
		}

		//Debug.Log(frontAxis);

	}
}
