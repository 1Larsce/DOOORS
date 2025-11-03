using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextScene; // Scene to load
    public int requiredLaptops; // Laptops needed to pass
    public AudioClip deniedSound; // Sound when not enough laptops
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.laptopsCollected >= requiredLaptops)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                PlayDeniedSound();
            }
        }
    }

    private void PlayDeniedSound()
    {
        if (deniedSound != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(deniedSound);
        }
    }
}
