using UnityEngine;


public sealed class CameraController : BaseController, IInitialization, IExecute
{
    private CameraFollow _cameraFollow;

    public void Initialization()
    {
        _cameraFollow = Object.FindObjectOfType<CameraFollow>();
    }

    public void Execute()
    {
        _cameraFollow.FollowPlayer(player);
    }
}