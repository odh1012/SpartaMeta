using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyUIManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isGameOver = false;

    void Start()
    {
        isGameOver = false;

        startButton.onClick.AddListener(OnStartClicked);
        exitButton.onClick.AddListener(OnExitClicked);

        if (scoreText == null)
            Debug.LogError("scoreText is null");

        ShowStartUI();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowStartUI()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void HideStartUI()
    {
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        isGameOver = true;
        ShowStartUI();
    }

    private void OnStartClicked()
    {
        if (isGameOver)
        {
            FlappyGameManager.Instance.RestartGame();
        }
        else
        {
            FlappyGameManager.Instance.StartGame();
        }
    }

    private void OnExitClicked()
    {
        SceneManager.LoadScene("Meta");
    }
}
