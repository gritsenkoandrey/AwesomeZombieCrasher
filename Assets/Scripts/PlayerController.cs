using UnityEngine;


public sealed class PlayerController : BaseController
{
    private Rigidbody _rigidbody;
    [SerializeField] private Transform _bulletStartPoint = null;
    [SerializeField] private GameObject _bulletPrefab = null;
    [SerializeField] private ParticleSystem _shootEffect = null;

    [SerializeField] private ButtonUi _shootButton = null;
    [SerializeField] private SliderUi _fireBar = null;

    //private Animator _shootSliderAnim;
    [HideInInspector] public bool ICanShoot;

    private float _forceBullet = 2000.0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ICanShoot = true;
        _shootButton.GetButton.onClick.AddListener(delegate { ShootingControl(); });
    }

    private void Update()
    {
        ControllMovementWithKeyboard();
        ChangeRotationVechicle();
    }

    private void FixedUpdate()
    {
        MoveVehicle();
    }

    private void MoveVehicle()
    {
        _rigidbody.MovePosition(_rigidbody.position + speed * Time.deltaTime);
    }

    private void ControllMovementWithKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    private void ChangeRotationVechicle()
    {
        if (Mathf.Round(speed.x) > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, maxAngle, 0.0f), Time.deltaTime * rotationSpeed);
        }
        else if (Mathf.Round(speed.x) < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, -maxAngle, 0.0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootingControl()
    {
        if (Time.timeScale != 0)
        {
            if (ICanShoot)
            {
                var bullet = Instantiate(_bulletPrefab, _bulletStartPoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().Move(_forceBullet);
                _shootEffect.Play();

                ICanShoot = false;
                _fireBar.GetComponent<Animator>().Play("Fill");
            }
        }
    }
}