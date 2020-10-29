using UnityEngine;


public class PlayerBaseController : MonoBehaviour
{
    private IMove _iMove;
    private IRotate _iRotate;

    private CurrentPlayerHealth _currenPlayerHealth;
    private UIHealth _uiHealth;
    private UiScore _uiScore;

    private void Awake()
    {
        _iMove = FindObjectOfType<CurrentPlayerMove>();
        _iRotate = FindObjectOfType<CurrentPlayerMove>();

        _uiHealth = FindObjectOfType<UIHealth>();
        _currenPlayerHealth = FindObjectOfType<CurrentPlayerHealth>();

        _uiScore = FindObjectOfType<UiScore>();
    }

    private void Update()
    {
        _iRotate.Rotate();
        _iMove.Move();

        _uiHealth.ShowCurrentHealth(_currenPlayerHealth);
        _uiScore.ShowScore();
    }
}