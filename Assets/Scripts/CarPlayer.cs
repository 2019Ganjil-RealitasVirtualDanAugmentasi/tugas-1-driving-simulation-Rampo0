using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayer : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		CarMovement car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMovement>();
		if (other.tag == "PowerUp") {
			Debug.Log("PowerUp");
			//Increase Speed
			car.IncreaseSpeed(other.GetComponent<PowerUp>().SpeedPower);
			Destroy(other.gameObject);
		}
	}
}
