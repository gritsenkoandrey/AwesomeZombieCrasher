using UnityEngine;


public abstract class BaseController
{
    protected UiInterface uiInterface;
    protected Transform player;

    protected BaseController()
    {
        uiInterface = new UiInterface();
        player = Object.FindObjectOfType<BasePlayer>().transform;
    }
}