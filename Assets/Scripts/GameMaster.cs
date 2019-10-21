using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	[SerializeField] private MeshRenderer playerCarMesh; 

	private void Start()
	{
		AudioManager.instance.JustPlayThisSound("background");
		playerCarMesh.material = CarSelect.instance.CurrentMaterial;
		
	}

}
