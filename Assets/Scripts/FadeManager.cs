using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
	private Animator anim;
	private string sceneName;
	
	private void Awake() {
		anim = GetComponent<Animator>();
	}

	public void LoadScene(string _sceneName) {
		anim.SetTrigger("FadeIn");
		sceneName = _sceneName;
	}

	public void OnFadeInEnd() {
		SceneManager.LoadSceneAsync(sceneName);
	}

	public void OnFadeOutEnd() {
		//this.gameObject.SetActive(false);
	}

}
