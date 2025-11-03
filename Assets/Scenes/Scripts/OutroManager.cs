using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OutroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("❌ VideoPlayer is not assigned!");
            return;
        }

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("🎬 Cutscene finished! Returning to main menu...");
        SceneManager.LoadScene("MainMenu"); // Change to "MainMenu" or another scene
    }
}
