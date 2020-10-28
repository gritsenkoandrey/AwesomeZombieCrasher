using UnityEngine;


public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _time = 3.0f;

    private void Start()
    {
        Invoke(nameof(DeactivateGameObject), _time);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}