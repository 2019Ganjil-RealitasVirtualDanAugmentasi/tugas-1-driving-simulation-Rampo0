using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	private FadeManager fadeInstance;

	public static SceneLoader instance = null;

	private void Awake()
	{
		if (instance)
		{
			Debug.LogWarning("There is more SceneLoader");
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public void LoadSceneFade(string sceneName) {
		fadeInstance = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeManager>();
		if (fadeInstance)
		{
			fadeInstance.LoadScene(sceneName);
		}
	}


}
