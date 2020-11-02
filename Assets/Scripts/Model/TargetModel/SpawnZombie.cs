using UnityEngine;


public sealed class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject[] _zombiePrefabs = null;

    private Vector3 _shift;
    private int _countZombie;

    public void AddZombie(Vector3 pos)
    {
        _countZombie = Random.Range(0, 3) + 1;

        for (int i = 0; i < _countZombie; i++)
        {
            _shift = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(1.0f, 10.0f));

            Instantiate(_zombiePrefabs[Random.Range(0, _zombiePrefabs.Length)],
                pos + _shift, Quaternion.identity);
        }
    }
}