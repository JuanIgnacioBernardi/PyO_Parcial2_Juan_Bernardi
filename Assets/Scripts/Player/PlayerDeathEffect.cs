using UnityEngine;
public class PlayerDeathEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private ParticleSystem deathParticles;
    private void OnEnable()
    {
        playerHealth.onDie += HandleDeath;
    }
    private void OnDisable()
    {
        playerHealth.onDie -= HandleDeath;
    }
    private void HandleDeath()
    {
        playerSprite.enabled = false;
        deathParticles.Play();
    }
}