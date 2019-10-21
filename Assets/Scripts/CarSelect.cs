using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelect : MonoBehaviour
{
	public static CarSelect instance;
	[SerializeField] private List<Material> carMaterial;
	private Material currentMaterial;

	public List<Material> CarMaterial { get => carMaterial; set => carMaterial = value; }
	public Material CurrentMaterial { get => currentMaterial; set => currentMaterial = value; }

	private void Awake()
	{
		if (instance)
		{
			Debug.LogWarning("There is more CarSelect");
			Destroy(this.gameObject);
		}
		else {

			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public void SelectCar(string name) {

		if (name == "lowoireng")
		{
			CurrentMaterial = CarMaterial[0];
		}
		else if (name == "sapuangin")
		{
			CurrentMaterial = CarMaterial[1];
		}
		

		SceneManager.LoadSceneAsync("LoadingScene");
	}
}
