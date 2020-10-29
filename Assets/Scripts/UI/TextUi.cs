using UnityEngine;
using UnityEngine.UI;


public class TextUi : MonoBehaviour
{
    private Text _text;

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
}