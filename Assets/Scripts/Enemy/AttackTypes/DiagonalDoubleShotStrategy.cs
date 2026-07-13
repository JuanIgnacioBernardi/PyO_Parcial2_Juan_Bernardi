using UnityEngine;
public class DiagonalDoubleShotStrategy : MonoBehaviour, IEnemyAttackStrategy
{
    [SerializeField] private EnemyAttackDataSO data;

    private static readonly Vector2 DiagonalRight = new Vector2(1f, -1f);
    private static readonly Vector2 DiagonalLeft = new Vector2(-1f, -1f);

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

        pool.Spawn(firePoint.position, DiagonalRight, data.bulletSpeed, data.damage, ProjectileOwner.Enemy);
        pool.Spawn(firePoint.position, DiagonalLeft, data.bulletSpeed, data.damage, ProjectileOwner.Enemy);
        timer = data.fireInterval;
    }
}