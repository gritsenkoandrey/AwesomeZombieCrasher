using UnityEngine;


public sealed class CurrentPlayerMove : BasePlayer, IMove, IRotate
{
    [SerializeField] private float _xSpeed = 0.0f;
    [SerializeField] private float _zSpeed = 0.0f;

    [SerializeField] private float _accelerated = 0.0f;
    [SerializeField] private float _deccelerated = 0.0f;

    private float _rotateSpeed = 10.0f;
    private float _angle = 10.0f;

    private bool _isSlow = false;

    private Rigidbody _myBody;

    protected override void Awake()
    {
        base.Awake();

        speed = new Vector3(0.0f, 0.0f, _zSpeed);
        _myBody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        _myBody.MovePosition(_myBody.position + speed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        speed = new Vector3(-_xSpeed, 0.0f, speed.z);
    }

    public void MoveRight()
    {
        speed = new Vector3(_xSpeed, 0.0f, speed.z);
    }

    public void MoveStraight()
    {
        speed = new Vector3(0.0f, 0.0f, speed.z);
    }

    public void MoveNormal()
    {
        if (_isSlow)
        {
            _isSlow = false;
        }

        speed = new Vector3(speed.x, 0.0f, _zSpeed);
    }

    public void MoveSlow()
    {
        if (!_isSlow)
        {
            _isSlow = true;
        }

        speed = new Vector3(speed.x, 0.0f, _deccelerated);
    }

    public void MoveFast()
    {
        speed = new Vector3(speed.x, 0.0f, _accelerated);
    }

    public void Rotate()
    {
        if (Mathf.Round(speed.x) > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, _angle, 0.0f), Time.deltaTime * _rotateSpeed);
        }
        else if (Mathf.Round(speed.x) < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, -_angle, 0.0f), Time.deltaTime * _rotateSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * _rotateSpeed);
        }
    }
}