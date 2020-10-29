using UnityEngine;


public sealed class CurrentPlayerHealth : BasePlayer
{
    [SerializeField] private float _maxHealth = 0.0f;
    private float _currentHealth;
    private readonly byte _minHealth = 0;

    public float CurrentHealth
    {
        get
        {
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            if (_currentHealth < _minHealth)
            {
                _currentHealth = _minHealth;
            }

            return _currentHealth;
        }

        private set { _currentHealth = value; }
    }

    protected override void Awake()
    {
        base.Awake();

        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
    }
}