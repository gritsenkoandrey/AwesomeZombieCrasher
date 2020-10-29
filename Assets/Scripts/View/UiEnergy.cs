using UnityEngine;


public sealed class UiEnergy : MonoBehaviour
{
    [SerializeField] private SliderUi _fireBar = null;

    public void ShootingAnim()
    {
        _fireBar.GetComponent<Animator>().Play("Fill");
    }

    private void ResetShooting()
    {
        CurrentPlayerFire.ICanShoot = true;
        _fireBar.GetComponent<Animator>().Play("Idle");
    }
}