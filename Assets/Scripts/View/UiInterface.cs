using UnityEngine;


public sealed class UiInterface
{
    private UiEnergy _uiEnergy;
    private UiHealth _uiHealth;
    private UiScore _uiScore;

    public UiEnergy UiEnergy
    {
        get
        {
            if(!_uiEnergy)
            {
                _uiEnergy = Object.FindObjectOfType<UiEnergy>();
            }

            return _uiEnergy;
        }
    }

    public UiHealth UiHealth
    {
        get
        {
            if (!_uiHealth)
            {
                _uiHealth = Object.FindObjectOfType<UiHealth>();
            }

            return _uiHealth;
        }
    }

    public UiScore UiScore
    {
        get
        {
            if (!_uiScore)
            {
                _uiScore = Object.FindObjectOfType<UiScore>();
            }

            return _uiScore;
        }
    }
}