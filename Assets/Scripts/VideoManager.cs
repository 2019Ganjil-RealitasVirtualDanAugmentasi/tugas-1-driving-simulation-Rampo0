using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
	private VideoPlayer videoPlayer;
	//public static VideoManager instance = null;

	public VideoPlayer _VideoPlayer { get => videoPlayer; set => videoPlayer = value; }
	private bool isPlay = false;
	[SerializeField] private string sceneName;

	private void Awake()
	{
		_VideoPlayer = GetComponent<VideoPlayer>();

		// Splash Screen Instant Play
		PlayVideo();
		
		/*if (instance)
		{
			Debug.LogWarning("There is more Video Manager");
			Destroy(this.gameObject);
		}
		else {
			
			instance = this;
			//DontDestroyOnLoad(this.gameObject);
		}*/
	}

	private void Update()
	{
		if (!videoPlayer.isPlaying && isPlay) {
			// When Video Stop
			Debug.Log("Video Stop");
			SceneLoader.instance.LoadSceneFade(sceneName);
			isPlay = false;
		}
		
	}

	public void SetVideoClip(VideoClip video) {
		//Set Url for play video
		
	}

	private void PlayVideo() {
		_VideoPlayer.Play();
		isPlay = true;
	}

}
