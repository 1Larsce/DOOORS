using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    public float timeRemaining = 300f;
    private bool isRunning = true;
    public TMP_Text timerText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                Debug.Log("⏳ Timer Ended! Exiting game...");
                Application.Quit();
            }
            UpdateTimerUI();
        }
    }

    public void StopTimer()
    {
        Debug.Log("🛑 Stopping and destroying GameTimer...");
        isRunning = false;
        Destroy(gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Outro")
        {
            return; // Don't run in Outro scene
        }
        FindTimerUI();
    }

    private void FindTimerUI()
    {
        if (timerText == null)
        {
            GameObject timerObj = GameObject.Find("TimerText");
            if (timerObj != null)
            {
                timerText = timerObj.GetComponent<TMP_Text>();
                Debug.Log("✅ TimerText (TMP) found!");
            }
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }
}
