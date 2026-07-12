using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ProjectilePool projectilePool;
    [SerializeField] private float baseDamage = 1f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireCooldown = 1f;

    private float cooldownTimer;
    public float DamageMultiplier { get; set; } = 1f;

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = fireCooldown;
        }
    }
    private void Shoot()
    {
        projectilePool.Spawn(firePoint.position, Vector2.up, bulletSpeed, baseDamage * DamageMultiplier, ProjectileOwner.Player);
    }
}