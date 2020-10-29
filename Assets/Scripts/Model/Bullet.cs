using UnityEngine;


public sealed class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _timeToDestroyBullet = 5.0f;

    public void Move(float speed)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward.normalized * speed);
        Invoke(nameof(DeactivateGameObject), _timeToDestroyBullet);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}