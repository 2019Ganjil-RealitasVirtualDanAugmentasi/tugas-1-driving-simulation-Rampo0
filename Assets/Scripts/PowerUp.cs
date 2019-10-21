using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	[SerializeField] private float speedPower;

	public float SpeedPower { get => speedPower; set => speedPower = value; }

	private void Update()
	{
		transform.Rotate(new Vector3(0, 1f, 0));
	}

}
