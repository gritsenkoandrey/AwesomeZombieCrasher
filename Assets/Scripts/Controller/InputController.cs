using UnityEngine;
using UnityEngine.UIElements;


public sealed class InputController : MonoBehaviour
{
    private readonly KeyCode _moveLeft = KeyCode.A;
    private readonly KeyCode _moveRight = KeyCode.D;
    private readonly KeyCode _moveFast = KeyCode.W;
    private readonly KeyCode _moveSlow = KeyCode.S;
    private readonly MouseButton _fire = MouseButton.LeftMouse;

    private IMove _iMove;
    private IFire _iFire;
    private UiEnergy _uiEnergy;

    private void Awake()
    {
        _iMove = FindObjectOfType<CurrentPlayerMove>();
        _iFire = FindObjectOfType<CurrentPlayerFire>();

        _uiEnergy = FindObjectOfType<UiEnergy>();
    }

    private void Update()
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

        if (Input.GetMouseButtonDown((int)_fire))
        {
            _iFire.Shoot();
            _uiEnergy.ShootingAnim();
        }
    }
}