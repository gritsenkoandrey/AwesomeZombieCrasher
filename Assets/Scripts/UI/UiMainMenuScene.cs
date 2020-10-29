using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class UiMainMenuScene : MonoBehaviour
{
    [SerializeField] private ButtonUi _playButton = null;
    [SerializeField] private Animator _animator = null;

    private void Awake()
    {
        _playButton.GetButton.onClick.AddListener(delegate { PlayGame(); });
    }

    private void PlayGame()
    {
        _animator.Play("Slide");
    }

    private void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}