using UnityEngine;


public class UIHealth : MonoBehaviour
{
    [SerializeField] private SliderUi _healthBar = null;
    private UiGameScene _uiGameScene;

    private void Awake()
    {
        _uiGameScene = FindObjectOfType<UiGameScene>();
    }

    public void ShowCurrentHealth(CurrentPlayerHealth health)
    {
        _healthBar.GetControl.value = health.CurrentHealth;

        if (health.CurrentHealth <= 0)
        {
            _uiGameScene.GameOver();
        }
    }
}