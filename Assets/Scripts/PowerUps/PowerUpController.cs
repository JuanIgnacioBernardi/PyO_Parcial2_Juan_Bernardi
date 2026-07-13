using UnityEngine;
using UnityEngine.InputSystem;
public class PowerUpController : MonoBehaviour
{
    [Header("Power-up Settings")]
    [SerializeField] private PowerUpBase shieldPowerUp;
    [SerializeField] private PowerUpBase strengthPowerUp;
    private void Update()
    {
        // if Q pressed, activate shield power-up
        if (Keyboard.current.qKey.wasPressedThisFrame) shieldPowerUp.Activate();

        // if W pressed, activate strength power-up
        if (Keyboard.current.wKey.wasPressedThisFrame) strengthPowerUp.Activate();
    }
}