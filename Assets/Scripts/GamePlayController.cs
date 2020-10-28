using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public sealed class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance;

    [SerializeField] private GameObject[] _obstaclesPrefabs;
    [SerializeField] private GameObject[] _zombiePrefabs;
    [SerializeField] private Transform[] _lanes;

    [SerializeField] private float _minObstacleDelay = 1.0f;
    [SerializeField] private float _maxObstacleDelay = 4.0f;

    private float _halfGroundSize;

    private BaseController _playerController;

    [SerializeField] private TextUi _scoreBar = null;
    [SerializeField] private Text _finalScore = null;
    private int _zombieKillCount;

    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;

    [SerializeField] private ButtonUi _pauseButton = null;
    [SerializeField] private ButtonUi _resumeButton = null;
    [SerializeField] private ButtonUi _exitButton = null;
    [SerializeField] private ButtonUi _restartButton = null;
    [SerializeField] private ButtonUi _menuButton = null;

    private void Awake()
    {
        MakeInstance();

        _pauseButton.GetButton.onClick.AddListener(delegate { PauseGame(); });
        _resumeButton.GetButton.onClick.AddListener(delegate { ResumeGame(); });
        _exitButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.AddListener(delegate { RestartGame(); });
        _menuButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
    }

    private void Start()
    {
        _halfGroundSize = FindObjectOfType<GroundBlock>().halfLenghth;
        _playerController = FindObjectOfType<PlayerController>();

        StartCoroutine(nameof(GenerateObstacles));
    }

    private void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GenerateObstacles()
    {
        float time = Random.Range(_minObstacleDelay, _maxObstacleDelay);
        yield return new WaitForSeconds(time);

        CreateObstacles(_playerController.gameObject.transform.position.z + _halfGroundSize);

        StartCoroutine(nameof(GenerateObstacles));
    }

    private void CreateObstacles(float zPos)
    {
        int r = Random.Range(0, 10);

        if (0 <= r && r < 7)
        {
            int obstacleLane = Random.Range(0, _lanes.Length);

            AddObstacle(new Vector3(_lanes[obstacleLane].transform.position.x, 0.0f, zPos),
                Random.Range(0, _obstaclesPrefabs.Length));

            int zombieLane = 0;

            if (obstacleLane == 0)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if (obstacleLane == 1)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obstacleLane == 2)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 1;
            }

            AddZombie(new Vector3(_lanes[zombieLane].transform.position.x, 0.0f, zPos));
        }
    }

    private void AddObstacle(Vector3 pos, int type)
    {
        GameObject obstacle = Instantiate(_obstaclesPrefabs[type], pos, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0.0f, mirror ? -20 : 20, 0.0f);
                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0.0f, mirror ? -20 : 20, 0.0f);
                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0.0f, mirror ? -1 : 1, 0.0f);
                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0.0f, mirror ? -170 : 170, 0.0f);
                break;
        }

        obstacle.transform.position = pos;
    }

    private void AddZombie(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;

        for (int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f), 0.0f, Random.Range(1.0f, 10.0f) * i);

            Instantiate(_zombiePrefabs[Random.Range(0, _zombiePrefabs.Length)],
                pos + shift * i, Quaternion.identity);
        }
    }

    public void IncreaseScore()
    {
        _zombieKillCount++;
        _scoreBar.GetText.text = _zombieKillCount.ToString();
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
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _finalScore.text = $"Killed: { _zombieKillCount }";
        Time.timeScale = 0.0f;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
}