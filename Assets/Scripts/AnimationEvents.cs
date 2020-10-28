using UnityEngine;
using UnityEngine.SceneManagement;



public class AnimationEvents : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _anim;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _anim = GetComponent<Animator>();
    }

    private void ResetShooting()
    {
        _playerController.ICanShoot = true;
        _anim.Play("Idle");
    }

    private void CameraStartGame()
    {
        SceneManager.LoadScene(1);
    }
}