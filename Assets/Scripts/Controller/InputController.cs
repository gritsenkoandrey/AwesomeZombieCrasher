using UnityEngine;


public sealed class InputController : BaseController, IExecute, IInitialization
{
    private readonly KeyCode _moveLeft = KeyCode.A;
    private readonly KeyCode _moveRight = KeyCode.D;
    private readonly KeyCode _moveFast = KeyCode.W;
    private readonly KeyCode _moveSlow = KeyCode.S;

    private readonly int _fire = (int)MouseButton.LeftButton;

    private IMove _iMove;
    private IFire _iFire;

    public InputController()
    {
        Cursor.visible = false;
    }

    public void Initialization()
    {
        _iMove = Object.FindObjectOfType<CurrentPlayerMove>();
        _iFire = Object.FindObjectOfType<CurrentPlayerFire>();
    }

    public void Execute()
    {
        if (Input.GetKeyDown(_moveLeft))
        {
            _iMove.MoveLeft();
        }

        if (Input.GetKeyDown(_moveRight))
        {
            _iMove.MoveRight();
        }

        if (Input.GetKeyDown(_moveFast))
        {
            _iMove.MoveFast();
        }

        if (Input.GetKeyDown(_moveSlow))
        {
            _iMove.MoveSlow();
        }

        if (Input.GetKeyUp(_moveLeft) || Input.GetKeyUp(_moveRight))
        {
            _iMove.MoveStraight();
        }

        if (Input.GetKeyUp(_moveFast) || Input.GetKeyUp(_moveSlow))
        {
            _iMove.MoveNormal();
        }

        if (Input.GetMouseButton(_fire))
        {
            _iFire.Shoot();
            uiInterface.UiEnergy.ShootingAnim();
        }
    }
}