using UnityEngine;


public abstract class BaseController : MonoBehaviour
{
    protected Vector3 speed;

    [SerializeField] private float _xSpeed = 0.0f;
    [SerializeField] private float _zSpeed = 0.0f;

    [SerializeField] private float _accelerated = 0.0f;
    [SerializeField] private float _deccelerated = 0.0f;

    protected float rotationSpeed = 10.0f;
    protected float maxAngle = 10.0f;

    [SerializeField] private float _lowSoundPitch = 0.0f;
    [SerializeField] private float _normalSoundPitch = 0.0f;
    [SerializeField] private float _highSoundPitch = 0.0f;

    [SerializeField] private AudioClip _engineOnSound = null;
    [SerializeField] private AudioClip _engineOffSound = null;

    private AudioSource _soundManager;

    private bool _isSlow;

    private void Awake()
    {
        _soundManager = GetComponent<AudioSource>();

        speed = new Vector3(0.0f, 0.0f, _zSpeed);
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-_xSpeed, 0.0f, speed.z);
    }

    protected void MoveRight()
    {
        speed = new Vector3(_xSpeed, 0.0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0.0f, 0.0f, speed.z);
    }

    protected void MoveNormal()
    {
        if (_isSlow)
        {
            _isSlow = false;

            _soundManager.Stop();
            _soundManager.clip = _engineOnSound;
            _soundManager.volume = 0.3f; //_lowSoundPitch
            _soundManager.Play();
        }

        speed = new Vector3(speed.x, 0.0f, _zSpeed);
    }

    protected void MoveSlow()
    {
        if (!_isSlow)
        {
            _isSlow = true;

            _soundManager.Stop();
            _soundManager.clip = _engineOffSound;
            _soundManager.volume = 0.5f; //_normalSoundPitch
            _soundManager.Play();
        }

        speed = new Vector3(speed.x, 0.0f, _deccelerated);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0.0f, _accelerated);
    }
}