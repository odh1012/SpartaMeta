using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    static FlappyGameManager flappygameManager;
    public static FlappyGameManager Instance { get { return flappygameManager; } }

    private int currentScore = 0;
    private bool isGameStarted = false;
    public bool IsGameStarted => isGameStarted;

    FlappyUIManager flappyuiManager;

    private void Awake()
    {
        flappygameManager = this;
        flappyuiManager = FindObjectOfType<FlappyUIManager>();
    }

    private void Start()
    {
        Time.timeScale = 0f; // ���� ����
        flappyuiManager.ShowStartUI();
        flappyuiManager.UpdateScore(0);
    }

    public void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1f; // ���� ����
        flappyuiManager.HideStartUI();
    }


    public void GameOver()
    {
        flappyuiManager.ShowGameOverUI();
        isGameStarted = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // �ð� �帧 �簳
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void AddScore(int score)
    {
        if (!isGameStarted) return;

        currentScore += score;
        flappyuiManager.UpdateScore(currentScore);
    }
}
