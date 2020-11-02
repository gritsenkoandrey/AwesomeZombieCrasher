using UnityEngine;


public sealed class SpawnRoad : MonoBehaviour
{
    [SerializeField] private Transform _otherBlock = null;

    private readonly float _fullLenghth = 200.0f;
    private readonly float _halfLenghth = 100.0f;
    private readonly float _endOffset = 10.0f;

    public void MoveGround(Transform player)
    {
        if (transform.position.z + _halfLenghth < player.transform.position.z - _endOffset)
        {
            transform.position = new Vector3(_otherBlock.position.x, _otherBlock.position.y,
                _otherBlock.position.z + _fullLenghth);
        }
    }
}