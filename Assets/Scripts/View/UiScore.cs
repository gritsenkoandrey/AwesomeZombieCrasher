using UnityEngine;


public sealed class UiScore : MonoBehaviour
{
    [SerializeField] private TextUi _scoreBar = null;

    public static int Score;

    private void Awake()
    {
        Score = 0;
    }

    public void ShowScore()
    {
        _scoreBar.GetText.text = $"Killed {Score}";
    }
}