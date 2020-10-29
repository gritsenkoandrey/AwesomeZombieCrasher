using UnityEngine;


public sealed class ZombieBase : MonoBehaviour
{
    [SerializeField] private GameObject _bloodEffect = null;

    private BasePlayer _basePlayer;
    private Bullet _bullet;


    private void OnCollisionEnter(Collision target)
    {
        _basePlayer = target.gameObject.GetComponent<BasePlayer>();
        _bullet = target.gameObject.GetComponent<Bullet>();

        if (_basePlayer || _bullet)
        {
            if (_bullet)
            {
                _bullet.gameObject.SetActive(false);
            }

            ShowBloodEffect();
            KillZombie();
        }
    }

    private void ShowBloodEffect()
    {
        Instantiate(_bloodEffect, transform.position, Quaternion.identity);
    }

    private void KillZombie()
    {
        UiScore.Score++;
        gameObject.SetActive(false);
    }
}