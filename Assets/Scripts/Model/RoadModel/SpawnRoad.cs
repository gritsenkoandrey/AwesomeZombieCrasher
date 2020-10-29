using UnityEngine;


public sealed class SpawnRoad : MonoBehaviour
{
    [SerializeField] private Transform _otherBlock = null;
    private Transform _player;

    private readonly float _fullLenghth = 200.0f;
    private readonly float _halfLenghth = 100.0f;
    private readonly float _endOffset = 10.0f;

    private void Awake()
    {
        _player = FindObjectOfType<BasePlayer>().transform;
    }

    private void Update()
    {
        MoveGround();
    }

    private void MoveGround()
    {
        if (transform.position.z + _halfLenghth < _player.transform.position.z - _endOffset)
        {
            transform.position = new Vector3(_otherBlock.position.x, _otherBlock.position.y,
                _otherBlock.position.z + _fullLenghth);
        }
    }
}