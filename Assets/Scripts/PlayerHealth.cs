using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int HealthValue = 100;
    [SerializeField] private SliderUi _healthBar;
    [SerializeField] private GameObject _uiHolder;

    private void Start()
    {
        _healthBar.GetControl.value = HealthValue;
    }

    public void ApplyDamage(int damageAmount)
    {
        HealthValue -= damageAmount;
        if (HealthValue < 0)
        {
            HealthValue = 0;
        }
        _healthBar.GetControl.value = HealthValue;

        if (HealthValue == 0)
        {
            _uiHolder.SetActive(false);
            GamePlayController.Instance.GameOver();
        }
    }
}