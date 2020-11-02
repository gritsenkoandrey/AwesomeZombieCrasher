using Scripts;
using UnityEngine;


public sealed class CurrentPlayerFire : BasePlayer, IFire
{
    [Range(0.0f, 5000.0f), SerializeField] private float _forceBullet = 0.0f;
    private float _recharge = 1.25f;
    private bool _iCanShoot = false;

    [SerializeField] private Transform _bulletStartPoint = null;
    [SerializeField] private Bullet _bulletPrefab = null;

    private TimeRemaining _timeToNextShoot;

    protected override void Awake()
    {
        base.Awake();

        _iCanShoot = true;
        _timeToNextShoot = new TimeRemaining(ReadyToShoot, _recharge);
    }

    public void Shoot()
    {
        if (Time.timeScale != 0)
        {
            if (_iCanShoot)
            {
                var bullet = Instantiate(_bulletPrefab, _bulletStartPoint.position, Quaternion.identity);

                bullet.Move(_forceBullet);

                _iCanShoot = false;
                _timeToNextShoot.AddTimeRemaining();
            }
        }
    }

    private void ReadyToShoot()
    {
        _iCanShoot = true;
        _timeToNextShoot.RemoveTimeRemaining();
    }
}