using UnityEngine;
public class ShieldPowerUp : PowerUpBase
{
    [Header("Shield Power-up Settings")]
    [SerializeField] private HealthSystem playerHealth;
    protected override void OnActivated()
    {
        playerHealth.isInvulnerable = true;
    }
    protected override void OnDeactivated()
    {
        playerHealth.isInvulnerable = false;
    }
}