using UnityEngine;
using TMPro;

public class DoorTrigger : MonoBehaviour
{
    public GameObject promptTextObject; // UI text GameObject
    public TextMeshProUGUI promptText;  // UI TextMeshPro component
    public string areaName; // Area name for the text

    public AudioSource enterAudioSource; // Separate AudioSource for entering
    public AudioSource exitAudioSource;  // Separate AudioSource for exiting

    private bool isPlayerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.text = areaName;
            promptTextObject.SetActive(true);
            isPlayerNear = true;

            // Play enter sound from its specific AudioSource
            if (enterAudioSource)
            {
                enterAudioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptTextObject.SetActive(false);
            isPlayerNear = false;

            // Play exit sound from its specific AudioSource
            if (exitAudioSource)
            {
                exitAudioSource.Play();
            }
        }
    }
}
