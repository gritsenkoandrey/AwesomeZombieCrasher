using UnityEngine;


public sealed class SmoothFollow : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _distance = 7.0f;
    [SerializeField] private float _height = 3.5f;

    [SerializeField] private float _heightDamping = 3.25f;
    [SerializeField] private float _rotationDamping = 0.25f;

    private void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float wantedRotationAngle = _target.eulerAngles.y;
        float wantedHeight = _target.position.y + _height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.Lerp
            (currentRotationAngle, wantedRotationAngle, _rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp
            (currentHeight, wantedHeight, _heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0.0f, currentRotationAngle, 0.0f);

        transform.position = _target.position;
        transform.position -= currentRotation * Vector3.forward * _distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }
}