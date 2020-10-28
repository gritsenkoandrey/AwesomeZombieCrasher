using UnityEngine;


public class Zombie : MonoBehaviour
{
    [SerializeField] private GameObject _bloodEffect = null;
    private float _speed;
    private float _timeDeactivate = 3.0f;
    private bool _isAlive;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = Random.Range(1.0f, 5.0f);
        _isAlive = true;
    }

    private void Update()
    {
        if (_isAlive)
        {
            _rigidbody.velocity = new Vector3(0.0f, 0.0f, -_speed);
        }

        if (transform.position.y < -10.0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        _isAlive = false;

        _rigidbody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        transform.localScale = new Vector3(1.0f, 1.0f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.GetComponent<PlayerController>() || target.gameObject.GetComponent<Bullet>())
        {
            Instantiate(_bloodEffect, transform.position, Quaternion.identity);

            Invoke(nameof(DeactivateGameObject), _timeDeactivate);

            GamePlayController.Instance.IncreaseScore();

            Die();
        }
    }
}