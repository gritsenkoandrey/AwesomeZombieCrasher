using UnityEngine;


public sealed class GroundBlock : MonoBehaviour
{
    [SerializeField] private Transform _otherBlock = null;
    internal float halfLenghth = 100.0f;
    private float _fullLenghth = 200.0f;

    private Transform _player;
    private float _endOffset = 10.0f;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        MoveGround();
    }

    private void MoveGround()
    {
        if (transform.position.z + halfLenghth < _player.transform.position.z - _endOffset)
        {
            transform.position = new Vector3(_otherBlock.position.x, _otherBlock.position.y,
                _otherBlock.position.z + _fullLenghth);
        }
    }
}