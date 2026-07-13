using UnityEngine;
public class StrengthPowerUp : PowerUpBase
{
    [Header("Strength Power-up Settings")]
    [SerializeField] private PlayerShoot playerShoot;
    [SerializeField] private float multiplier = 2f;
    protected override void OnActivated()
    {
        playerShoot.DamageMultiplier = multiplier;
    }
    protected override void OnDeactivated()
    {
        playerShoot.DamageMultiplier = 1f;
    }
}