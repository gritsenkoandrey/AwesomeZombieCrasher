using UnityEngine;


public class ObstacleBase : MonoBehaviour
{
    [SerializeField] private float _damage = 0.0f;
    [SerializeField] private GameObject _explosionPrefab = null;

    private CurrentPlayerHealth _playerHealth;
    private Bullet _bullet;


    private void OnCollisionEnter(Collision target)
    {
        _playerHealth = target.gameObject.GetComponent<CurrentPlayerHealth>();

        if (_playerHealth)
        {
            _playerHealth.ApplyDamage(_damage);
            ShowExplosion();
            DestroyObstacle();
        }

        _bullet = target.gameObject.GetComponent<Bullet>();

        if (_bullet)
        {
            _bullet.gameObject.SetActive(false);
            ShowExplosion();
            DestroyObstacle();
        }
    }

    private void ShowExplosion()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }

    private void DestroyObstacle()
    {
        gameObject.SetActive(false);
    }
}