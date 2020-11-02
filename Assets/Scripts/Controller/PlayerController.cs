using UnityEngine;


public sealed class PlayerController : BaseController, IInitialization, IExecute
{
    private CurrentPlayerMove _currentPlayerMove;
    private CurrentPlayerHealth _currentPlayerHealth;

    public void Initialization()
    {
        _currentPlayerMove = Object.FindObjectOfType<CurrentPlayerMove>();
        _currentPlayerHealth = Object.FindObjectOfType<CurrentPlayerHealth>();
    }

    public void Execute()
    {
        if (player != null)
        {
            _currentPlayerMove.Move();
            _currentPlayerMove.Rotate();

            uiInterface.UiHealth.ShowCurrentHealth(_currentPlayerHealth);
            uiInterface.UiScore.ShowScore();
        }
    }
}