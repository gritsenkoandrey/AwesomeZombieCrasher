using UnityEngine;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private ButtonUi _playButton = null;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _playButton.GetButton.onClick.AddListener(delegate { PlayGame(); });
    }

    public void PlayGame()
    {
        _animator.Play("Slide");
    }
}