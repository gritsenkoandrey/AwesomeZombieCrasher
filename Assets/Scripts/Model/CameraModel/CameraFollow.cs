using UnityEngine;


public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _distance = 7.0f;
    [SerializeField] private float _height = 3.5f;

    [SerializeField] private float _heightDamping = 3.25f;
    [SerializeField] private float _rotationDamping = 0.25f;

    private float _wantedRotationAngle;
    private float _wantedHeight;

    private float _currentRotationAngle;
    private float _currentHeight;
    private Quaternion _currentRotation;

    public void FollowPlayer(Transform player)
    {
        _wantedRotationAngle = player.eulerAngles.y;
        _wantedHeight = player.position.y + _height;

        _currentRotationAngle = transform.eulerAngles.y;
        _currentHeight = transform.position.y;

        _currentRotationAngle = Mathf.Lerp
            (_currentRotationAngle, _wantedRotationAngle, _rotationDamping * Time.deltaTime);

        _currentHeight = Mathf.Lerp
            (_currentHeight, _wantedHeight, _heightDamping * Time.deltaTime);

        _currentRotation = Quaternion.Euler(0.0f, _currentRotationAngle, 0.0f);

        transform.position = player.position;
        transform.position -= _currentRotation * Vector3.forward * _distance;
        transform.position = new Vector3(transform.position.x, _currentHeight, transform.position.z);
    }
}