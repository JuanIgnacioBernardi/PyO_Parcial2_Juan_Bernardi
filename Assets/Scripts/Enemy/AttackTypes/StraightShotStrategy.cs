using UnityEngine;
public class StraightShotStrategy : MonoBehaviour, IEnemyAttackStrategy
{
    [SerializeField] private EnemyAttackDataSO data;

    private Transform firePoint;
    private ProjectilePool pool;
    private float timer;

    public void Init(Transform origin, ProjectilePool projectilePool)
    {
        firePoint = origin;
        pool = projectilePool;
        timer = data.fireInterval;
    }

    public void Tick(float deltaTime)
    {
        timer -= deltaTime;
        if (timer > 0f) return;

        pool.Spawn(firePoint.position, Vector2.down, data.bulletSpeed, data.damage, ProjectileOwner.Enemy);
        timer = data.fireInterval;
    }
}