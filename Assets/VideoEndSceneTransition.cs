using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndSceneTransition : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField] private string nextScene; // Scene name holder in the Inspector

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component missing from GameObject!");
            return;
        }

        videoPlayer.loopPointReached += OnVideoEnd;

        // Optional: Start video if not playing
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.LogError("Next scene name is not set in the Inspector!");
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
