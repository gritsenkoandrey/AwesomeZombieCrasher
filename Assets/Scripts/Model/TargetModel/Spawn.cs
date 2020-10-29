using System.Collections;
using UnityEngine;


public sealed class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesPrefabs = null;
    [SerializeField] private GameObject[] _zombiePrefabs = null;
    [SerializeField] private Transform[] _lanes = null;
    private BasePlayer _basePlayer;

    [SerializeField] private float _minObstacleDelay = 1.0f;
    [SerializeField] private float _maxObstacleDelay = 4.0f;
    private readonly float _halfGroundSize = 100.0f;

    private void Start()
    {
        _basePlayer = FindObjectOfType<BasePlayer>();

        StartCoroutine(nameof(GenerateObstacles));
    }

    IEnumerator GenerateObstacles()
    {
        float time = Random.Range(_minObstacleDelay, _maxObstacleDelay);
        yield return new WaitForSeconds(time);

        CreateObstacles(_basePlayer.gameObject.transform.position.z + _halfGroundSize);

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
}