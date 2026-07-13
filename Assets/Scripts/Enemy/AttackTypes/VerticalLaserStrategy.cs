using UnityEngine;
public class VerticalLaserStrategy : MonoBehaviour, IEnemyAttackStrategy
{
    [Header("Laser Settings")]
    [SerializeField] private EnemyAttackDataSO data;
    [SerializeField] private LaserBeam laserBeam;
    [SerializeField] private float laserDuration = 2f;

    private float timer;
    private bool laserActive;
    public void Init(Transform origin, ProjectilePool projectilePool)
    {
        laserBeam.SetDamage(data.damage);
        laserBeam.gameObject.SetActive(false);
        timer = data.fireInterval;
    }
    public void Tick(float deltaTime)
    {
        timer -= deltaTime;
        if (timer > 0f) return;

        if (!laserActive)
        {
            laserActive = true;
            laserBeam.gameObject.SetActive(true);
            timer = laserDuration;
        }
        else
        {
            laserActive = false;
            laserBeam.gameObject.SetActive(false);
            timer = data.fireInterval;
        }
    }
}