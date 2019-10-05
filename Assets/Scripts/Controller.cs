using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Controller : MonoBehaviour
{

	protected enum InputType {
		Xbox,Steer,Keyboard
	}

	//protected float verticalAxis;
	//protected float horizontalAxis;
	[SerializeField] protected InputType controller;
	
	
}
