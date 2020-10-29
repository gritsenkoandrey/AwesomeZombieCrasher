using UnityEngine;


public sealed class CurrentPlayerFire : BasePlayer, IFire
{
    [SerializeField] private Transform _bulletStartPoint = null;
    [SerializeField] private Bullet _bulletPrefab = null;
    [Range(0.0f, 5000.0f), SerializeField] private float _forceBullet = 0.0f;

    public static bool ICanShoot = false;

    protected override void Awake()
    {
        base.Awake();

        ICanShoot = true;
    }

    public void Shoot()
    {
        if (Time.timeScale != 0)
        {
            if (ICanShoot)
            {
                var bullet = Instantiate(_bulletPrefab, _bulletStartPoint.position, Quaternion.identity);

                bullet.Move(_forceBullet);
                //todo timeremaining

                ICanShoot = false;
            }
        }
    }
}