using UnityEngine;
public interface IEnemyAttackStrategy
{
    void Init(Transform firePoint, ProjectilePool projectilePool);
    void Tick(float deltaTime);
}