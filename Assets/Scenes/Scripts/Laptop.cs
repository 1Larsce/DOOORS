using UnityEngine;

public class Laptop : MonoBehaviour
{
    public AudioClip collectSound; // Assign sound in Inspector
    private AudioSource audioSource;
    private bool isCollected = false; // Prevents multiple triggers

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Prevents multiple triggers
            GameManager.Instance.CollectLaptop();
            PlayCollectSound();
        }
    }

    private void PlayCollectSound()
    {
        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
            Destroy(gameObject, collectSound.length); // Destroy AFTER sound finishes
        }
        else
        {
            Destroy(gameObject); // If no sound, destroy immediately
        }
    }
}
