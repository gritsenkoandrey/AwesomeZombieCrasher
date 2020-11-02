using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public sealed class UiGameScene : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;

    [SerializeField] private ButtonUi _pauseButton = null;
    [SerializeField] private ButtonUi _resumeButton = null;
    [SerializeField] private ButtonUi _exitButton = null;
    [SerializeField] private ButtonUi _restartButton = null;
    [SerializeField] private ButtonUi _menuButton = null;

    [SerializeField] private Text _finalScore = null;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        _pauseButton.GetButton.onClick.AddListener(delegate { PauseGame(); });
        _resumeButton.GetButton.onClick.AddListener(delegate { ResumeGame(); });
        _exitButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.AddListener(delegate { RestartGame(); });
        _menuButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
    }

    private void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _finalScore.text = $"Killed {UiScore.Score}";
        Time.timeScale = 0.0f;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}