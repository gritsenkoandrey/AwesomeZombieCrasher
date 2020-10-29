using UnityEngine;
using UnityEngine.UI;


public sealed class SliderUi : MonoBehaviour
{
    private Text _text;
    private Slider _control;

    public Text GetText
    {
        get
        {
            if (!_text)
            {
                _text = transform.GetComponentInChildren<Text>();
            }
            return _text;
        }
    }

    public Slider GetControl
    {
        get
        {
            if (!_control)
            {
                _control = GetComponentInChildren<Slider>();
            }
            return _control;
        }
    }
}