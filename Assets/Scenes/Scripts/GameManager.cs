using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int laptopsCollected = 0; // Tracks collected laptops

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager active between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectLaptop()
    {
        laptopsCollected++;
    }
}
