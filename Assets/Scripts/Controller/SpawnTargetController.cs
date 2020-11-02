using Scripts;
using UnityEngine;


public sealed class SpawnTargetController : BaseController, IInitialization
{
    private readonly float _minDelay = 1.0f;
    private readonly float _maxDelay = 4.0f;
    private readonly float _halfGroundSize = 100.0f;

    private readonly float[] _lanes = { -1.85f, 0.0f, 1.85f };
    private int _obstacleLane;
    private int _zombieLane;

    private SpawnObstacle _spawnObstacle;
    private SpawnZombie _spawnZombie;

    private TimeRemaining _timeToSpawn;

    public void Initialization()
    {
        _spawnObstacle = Object.FindObjectOfType<SpawnObstacle>();
        _spawnZombie = Object.FindObjectOfType<SpawnZombie>();

        _timeToSpawn = new TimeRemaining(SpawnTarget, Random.Range(_minDelay, _maxDelay), true);

        _timeToSpawn.AddTimeRemaining();
    }

    private void SpawnTarget()
    {
        if (player != null)
        {
            Create(player.transform.position.z + _halfGroundSize);
        }
    }

    private void Create(float zPos)
    {
        if (Random.Range(0, 2) == 1)
        {
            _obstacleLane = Random.Range(0, _lanes.Length);

            _spawnObstacle.AddObstacle(new Vector3(_lanes[_obstacleLane], 0.0f, zPos));

            if (_obstacleLane == 0)
            {
                _zombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if (_obstacleLane == 1)
            {
                _zombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (_obstacleLane == 2)
            {
                _zombieLane = Random.Range(0, 2) == 1 ? 0 : 1;
            }

            _spawnZombie.AddZombie(new Vector3(_lanes[_zombieLane], 0.0f, zPos));
        }
    }
}