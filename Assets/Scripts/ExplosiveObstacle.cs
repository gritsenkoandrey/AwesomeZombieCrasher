using UnityEngine;


public class ExplosiveObstacle : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _damage = 20;

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.GetComponent<PlayerController>())
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

            target.gameObject.GetComponent<PlayerHealth>().ApplyDamage(_damage);

            gameObject.SetActive(false);
        }

        if (target.gameObject.GetComponent<Bullet>())
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            target.gameObject.GetComponent<Bullet>().gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}