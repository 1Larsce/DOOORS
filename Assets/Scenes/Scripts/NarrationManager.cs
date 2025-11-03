using UnityEngine;
using System.Collections;

public class NarrationManager : MonoBehaviour
{
    public AudioSource[] narrations; // Assign in Inspector

    private void Start()
    {
        int laptopCount = GameManager.Instance.laptopsCollected;

        if (laptopCount < narrations.Length && narrations[laptopCount] != null)
        {
            narrations[laptopCount].Play();
            if (laptopCount == narrations.Length - 1)
            {
                StartCoroutine(PlayCutsceneAfterNarration(narrations[laptopCount]));
            }
        }
    }

    private IEnumerator PlayCutsceneAfterNarration(AudioSource narration)
    {
        yield return new WaitWhile(() => narration.isPlaying);

        Debug.Log("🎬 Last narration finished! Stopping timer...");

        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.StopTimer();  // Stop & destroy the timer
        }

        // Load Outro scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Outro");
    }
}
