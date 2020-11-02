using UnityEngine;


public sealed class SpawnRoadController : BaseController, IInitialization, IExecute
{
    private SpawnRoad[] _spawnRoad;

    public void Initialization()
    {
        _spawnRoad = Object.FindObjectsOfType<SpawnRoad>();
    }

    public void Execute()
    {
        for (int i = 0; i < _spawnRoad.Length; i++)
        {
            _spawnRoad[i].MoveGround(player);
        }
    }
}