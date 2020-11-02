using UnityEngine;


public sealed class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclesPrefabs = null;

    private int _obstaclesType;

    public void AddObstacle(Vector3 pos)
    {
        _obstaclesType = Random.Range(0, _obstaclesPrefabs.Length);

        Instantiate(_obstaclesPrefabs[_obstaclesType], pos, Quaternion.identity);
    }
}