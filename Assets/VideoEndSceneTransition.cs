using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndSceneTransition : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the Video Player component
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the video end event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // This method will be called when the video ends
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene
       SceneManager.LoadScene("StartSplash");
    }

    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
